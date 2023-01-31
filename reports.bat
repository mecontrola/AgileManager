@echo off

if not exist "%~dp0BuildReports" mkdir "%~dp0BuildReports"

rd /s /q %~dp0BuildReports

dotnet restore --nologo --verbosity=minimal --force

dotnet build --nologo --verbosity=minimal --no-restore

dotnet test --results-directory %~dp0BuildReports/UnitTests ^
            --collect:"XPlat Code Coverage" ^
			--nologo ^
            --no-restore ^
            --no-build ^
            --verbosity=minimal ^
            /p:CollectCoverage=true ^
            /p:CoverletOutput="%~dp0BuildReports/Coverage/" ^
            /p:CoverletOutputFormat=cobertura ^
            /p:Exclude="[xunit.*]*%2c[MeControla.*]MeControla.AgileManager.DataStorage.Migrations.*%2c[MeControla.AgileManager.TestingTools]*"

reportgenerator -reports:%~dp0BuildReports\UnitTests\**\*.cobertura.xml ^
                -targetdir:%~dp0BuildReports\Coverage ^
                -assemblyfilters:"-xunit*;-MeControla.AgileManager.TestingTools;" ^
                -classfilters:"-MeControla.AgileManager.DataStorage.Migrations.*" ^
                -reporttypes:HTML;HTMLSummary

REM start "report" "%~dp0BuildReports\Coverage\index.html"