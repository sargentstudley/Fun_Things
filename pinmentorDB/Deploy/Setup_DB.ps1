<#
.SYNOPSIS
   Creates basic DB needed for testing
 
   
.DESCRIPTION
   Deploys a linux container running SQL Server 2019, creates the db for testing and the needed users 
 
.Parameter SApass
The SA password for the db
 
.Parameter Path
The enviroment path for the script that create the db
 
.EXAMPLE
   ./Setup_DB.ps1 -SApass 'OMG!Passwords@reFUN12' -Path 'C:\Users\Michael Tavares\Documents\Workspace\DB_Design\Liquibase\'
    
.NOTES
    Author: Michael Tavares
    Last Edit: 2020-02-09
<<<<<<< HEAD
    Version 1.0 its just ok 
#>


#where the magic happens
function Main {

    #Generates Creds for SA 
    $Credentials = Request-Credentials -UserName Sa
        
        #For testing - please remove later
        $testpass = $Credentials.GetNetworkCredential().Password
        #For testing - please remove later
        Write-Host "The current SA Password is $testpass" -ForegroundColor Green -BackgroundColor Red

    #Deploys SQL Engine is SA Account
    DeploySQL $Credentials

    #Deploys DB with Default User
    DeployDB $Credentials

    #changes Default app user's password
    ChangeMe $Credentials
     
    

 } #Main



function DeploySQL {
    Param(
        #SA Password for container
        [Parameter(Mandatory=$true)][System.Management.Automation.PSCredential] $Credentials
    )

    $SAPass = $Credentials.GetNetworkCredential().Password
    

    if (Get-Module -ListAvailable -Name sqlserver) {
        Write-Host "sqlserver Module exists"
    } 
    else {
        Write-error "sqlserver Module does not exist"
        Write-Information "Please open install Install-Module sqlserver, if on windows this must be done as Administrator "
    }



    #Check that Docker is installed
    $status = docker stats --no-stream

    if($status)
    {
        Write-host "Good Docker is installed"
    }
    else {
        Write-Error "You don't have docker or daemin isn't running, go to https://hub.docker.com/ and try  again!"
        Break
    }

    #Pull Latest MSSQL Image
    docker pull mcr.microsoft.com/mssql/server:2019-latest 

    docker run -e ACCEPT_EULA=Y -e SA_PASSWORD=$SApass -p 1433:1433 -d mcr.microsoft.com/mssql/server:2019-latest

    #allows the SQL Engine to fully start
    Start-Sleep -Seconds 20

    

}#DeploySQL

function DeployDB {

# SA Password to connect to sql
Param(
    #SA Password for container
    [Parameter(Mandatory=$true)][System.Management.Automation.PSCredential] $Credentials
)

#$SAPass = $Credentials.GetNetworkCredential().Password
    

    #Run DB Creation script & Run User script
    Invoke-Sqlcmd  -ServerInstance localhost -Credential $Credentials -InputFile "./Base_DB_Deploy.sql"

}#DeployDB

function Request-Credentials {
    Param(
        #SA Password for container
        [Parameter(Mandatory=$true)]$UserName
    )

    $minLength = 20 ## characters
    $maxLength = 35 ## characters
    $length = Get-Random -Minimum $minLength -Maximum $maxLength
    $nonAlphaChars = 10
    $password = [System.Web.Security.Membership]::GeneratePassword($length, $nonAlphaChars)

    $SecurePassword = $password | ConvertTo-SecureString -AsPlainText -Force

    $Credentials = New-Object System.Management.Automation.PSCredential -ArgumentList $UserName, $SecurePassword

    return $Credentials
    
}#Request-Credentials

#changes Default app user and saves to "vault"
function ChangeMe {
    Param(
        #SA Password for container
        [Parameter(Mandatory=$true)][System.Management.Automation.PSCredential] $Credentials
    )

    Write-Host "changing App Users Password"

    #Creates new password for default app user
    $NewCredentials = Request-Credentials -UserName PinMentor_app

    #Uses SA password to reset the default app user
    Set-DbaLogin -SqlInstance localhost -SqlCredential $Credentials -Login PinMentor_app -SecurePassword $NewCredentials

    #For testing - please remove later
    $testApppass = $NewCredentials.GetNetworkCredential().Password
    #For testing - please remove later
    Write-Host "The current PinMentor_app Password is $testApppass" -ForegroundColor Green -BackgroundColor Red


Write-Host "change complete"

Write-Host "test change?"

    try {
        Test-DbaLoginPassword -SqlInstance localhost -SqlCredential $NewCredentials -EnableException   
        Write-Host "Password test Successful!" -ForegroundColor Blue
    }
    catch {Write-Error "The New Default App User Password is Not Set Correctly"
        
    }
    
    
}#ChangeMe

Main