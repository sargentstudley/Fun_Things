# Readme

## Dependencies
* Docker
* Dotnet SDK (3.1.1)
* Node 13.8
* Vue CLI 3

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
* Vue
  * Install NodeJS
  * Install Vue cli: ```npm install -g @vue/cli```

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