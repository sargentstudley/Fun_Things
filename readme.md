# Readme

## Dependencies
* Docker
* .NET SDK

## Local Setup
* install vscode
* install c# plugin
* install .net core sdk
    * https://docs.microsoft.com/en-us/dotnet/core/install/linux-package-manager-ubuntu-1904
* 

## Build and Run
* ```bash ./scripts/CreateAllDockerImages.sh```
* ```bash ./scripts/RunDockerContainer.sh```

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
