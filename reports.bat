@echo off

if not exist "%~dp0BuildReports" mkdir "%~dp0BuildReports"

rd /s /q %~dp0BuildReports

dotnet restore --force %~dp0Stefanini.sln

dotnet build %~dp0Stefanini.sln

dotnet test %~dp0Stefanini.sln ^
            --logger "trx;LogFileName=TestResults.trx" ^
            --logger "xunit;LogFileName=TestResults.xml" ^
            --results-directory %~dp0BuildReports/UnitTests ^
            --collect:"XPlat Code Coverage" ^
            --no-build ^
            /p:CollectCoverage=true ^
            /p:CoverletOutput="%~dp0BuildReports/Coverage/" ^
            /p:CoverletOutputFormat=cobertura ^
            /p:Exclude="[xunit.*]*

dotnet "%~dp0tools\ReportGenerator.dll" ^
           -reports:%~dp0BuildReports\Coverage\coverage.cobertura.xml ^
           -targetdir:%~dp0BuildReports\Coverage ^
           -reporttypes:HTML;HTMLSummary

start "report" "%~dp0BuildReports\Coverage\index.html"