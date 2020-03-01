# Readme

## Overview

Placeholder for project description.

What is it?

Who is it for?

## Dependencies

* Dotnet SDK (3.1.1)
<<<<<<< HEAD
* Install-Module -Name Pester -Force -SkipPublisherCheck
* Install-Module -Name sqlserver
* Install-Module dbatools

=======
* Docker
* Node 13.8
* Vue CLI 3

### Local Setup
>>>>>>> master

1. Install [Git](https://www.atlassian.com/git/tutorials/install-git)
2. Download and install [Visual Studio Code](https://code.visualstudio.com/)
    * Recommended Extensions:
        * ms-vscode.csharp
        * streetsidesoftware.code-spell-checker
        * ms-azuretools.vscode-docker
        * vscode-icons-team.vscode-icons
        * k--kato.docomment
        * fernandoescolar.vscode-solution-explorer
        * GitLens - [eamodio.gitlens](https://marketplace.visualstudio.com/items?itemName=eamodio.gitlens)
3. Install [.NET Core SDK](https://dotnet.microsoft.com/download/dotnet-core/sdk-for-vs-code)
    * https://docs.microsoft.com/en-us/dotnet/core/install/linux-package-manager-ubuntu-1904
4. Install [Docker](https://docs.docker.com/install/)
5. Install VSCode extensions for PlantUML (Visio-like diagramming tool)
    * PlantUML - `jebbs.plantuml`
    * PlantUML Previewer - `mebrahtom.plantumlpreviewer`
    * File (or Code) > Preferences > Extensions > PlantUML configuration
        * Set "Render" to plantUmlServer
        * Set "Server" to http://localhost:8080
        * Run in Terminal: ```sudo docker run -d -p 8080:8080 plantuml/plantuml-server:jetty```
            * Enter local machine password when prompted
6. Download and install [NodeJS](https://nodejs.org/en/download/)
7. Install [Vue CLI](https://cli.vuejs.org/)
    * Run in Terminal: ```sudo npm install -g @vue/cli```

## Build and Run

* For Dotnet Services: CD into the project folder and run 'dotnet build' or 'dotnet run' or 'dotnet test' (if in a test project)
* For Vue Services: CD into the project folder and run ```npm build``` or ```npm run test:unit``` to test.
  * You can also use the Vue UI, which came included when you installed the vue cli. Run ```vue ui``` in a terminal to start it. Follow directions on screen to register the folder that contains the root of the vue project. You can use this to run mocha tests, and get telemetry data as you serve the vue app.

## Testing Practices

* All services should have test coverage of functional code. Ideally - tests are written first and serve as both the requirements and the tests - at the same time.
* Here are the testing technologies currently used:
  * Dotnet
    * Specflow for BDD tests. Feature files are written using gherkin: https://cucumber.io/docs/gherkin/reference/
      * Write a feature file, and then create a matching steps file in the steps folder. 
      * Use ```dotnet watch test``` to re-run the test suite when ever you save to disk. 
      * For Coverage reports: ```dotnet test /p:CollectCoverage=true /p:CoverletOutputFormat=lcov /p:CoverletOutput=./lcov.info```
        * Use vscode plugin ryanluker.vscode-coverage-gutters to view coverage in vscode. 
  * Vue
    * Mocha (Test framework) Chai (Assertion framework) for BDD tests. Files are stored under test/unit.
      * Reference mocha documentation here: https://mochajs.org/
      * Reference chai documentation here: https://www.chaijs.com/
      * Use ```npm run test:unit``` to run tests, or access the mocha test runner from the Vue UI.

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