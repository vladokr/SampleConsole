# Sample Console application

## Development Enviroment & Tools
The application is developed using .NET Core 2.2 and Visual Studio Comunity Edition 2017.

## Architecture
The application follows the Clean Architecture and it is composed of three components:
* Parser.Core - represents the main (CORE) business logic. This module does not depend from anything except the .NET Core framework classes
* Parser.Infrastructure - it provides implementation for interfaces specifed in the Core module like TextWriter, Logger etc.
* Parser.ConsoleClient - an example of a simple Console Client application that uses the Parser.Core
Furthermore, there are two unit test projects:
* Parser.Core.Tests - unit tests for Parser.Core business services
* Parser.Infrastructure.Tests - unit tests for Parser.Infrastructure infrastructure services

## Configuration
Before running the application it is necessary to configure the parameters in Parser/Parser.ConsoleClient/appsettings.json file:
- ReportTitle - a Tite of the report which is written as a first line
- Separator - a string separator to divide the values in the report

Furthermore, if ReportOutputFilePath, LogFilePath and TextToAnalyzePath are left empty then default values are assigned to them like:
* ReportOutputFilePath - {current directory}\report.txt
* LogFilePath - {current directory}\log.txt
* TextToAnalyzePath - {current directory}\input.txt

## How to run the application?
* clone the git repository
* navigate to SampleConsole folder
* build the project with: dotnet build
* run the console application with: dotnet run --project ./Parser/Parser.ConsoleClient

### In Visual Studio
* open the solution file SampleConsole.sln
* run the Parser.ConsoleClient application
