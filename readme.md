# Readme

## Dependencies
* Docker
* Dotnet SDK (3.1.1)

## Local Setup
* install vscode
    * Standard Extensions:
        * ms-vscode.csharp
        * streetsidesoftware.code-spell-checker
        * ms-azuretools.vscode-docker
        * vscode-icons-team.vscode-icons
        * k--kato.docomment
        * fernandoescolar.vscode-solution-explorer
* install .net core sdk
    * https://docs.microsoft.com/en-us/dotnet/core/install/linux-package-manager-ubuntu-1904
* PlantUML
    * VSCode Extensions: "jebbs.plantuml", "mebrahtom.plantumlpreviewer"
    * File -> Preferences -> Extensions
        * Under PlantUml Configuration
        * Set "Render" to plantUmlServer
        * Set "Server" to http://localhost:8080
        * Run ```sudo docker run -d -p 8080:8080 plantuml/plantuml-server:jetty```

## Build and Run
* CD into the project folder and run 'dotnet build' or 'dotnet run' or 'dotnet test' (if in a test project)

## Example Plant syntax

```plantuml
skinparam backgroundColor BurlyWood

participant xyz as z
participant abc as a

z -> a : MethodCall()

```

## Infrastructure plan
* https://www.portainer.io/installation/
* http://www.liquibase.org/
* Docker
* Powershell (powershell for linux)