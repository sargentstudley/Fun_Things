$here = Split-Path -Parent $MyInvocation.MyCommand.Path
$sut = (Split-Path -Leaf $MyInvocation.MyCommand.Path) -replace '\.Tests\.', '.'
. "$here\$sut"

Describe "SQL Databases" {
    Context "Check SQL is running" {
        $db_results = Find-DbaInstance -ComputerName localhost
        foreach ($db in $db_results) {
            it "Server is listening on port 1433" {
                $db.port = '1433' | should be $true
            }
        }
    }
}

Describe "DeployDB" {
    It "Checks for basic schema" {
        $true | Should -Be $false
    }
}
