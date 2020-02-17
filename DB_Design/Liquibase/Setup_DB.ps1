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
    Version 1.0 its just ok 
#>

Param(
    $SApass="Password1!"
)

#This module may need to be run as admin before running the script
Install-Module sqlserver

#Check that Docker is installed
$version = docker version

if($version)
{
    Write-host "Good Docker is installed"
}
else {
    Write-Error "You don't have docker, go to https://hub.docker.com/ and try  again!"
    Break
}


#Pull Latest MSSQL Image
docker pull mcr.microsoft.com/mssql/server:2019-latest 

docker run -e ACCEPT_EULA=Y -e SA_PASSWORD=$SApass -p 1433:1433 -d mcr.microsoft.com/mssql/server:2019-latest

#allows the SQL Engine to fully start
Start-Sleep -Seconds 20

#Run DB Creation script & Run User script
Invoke-Sqlcmd  -ServerInstance localhost -Username SA -Password $SApass -InputFile "./DB_Design/Liquibase/Base_DB_Deploy.sql"


