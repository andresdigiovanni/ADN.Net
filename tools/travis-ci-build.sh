#!/bin/sh
echo "Executing MSBuild DLL begin command..."
dotnet ./tools/sonar/SonarScanner.MSBuild.dll begin /o:"andresdigiovanni-github" /k:"andresdigiovanni_ADN.Net" /d:sonar.cs.opencover.reportsPaths="./tests/ADN.Net.Tests/coverage.opencover.xml" /d:sonar.exclusions="**/bin/**/*,**/obj/**/*" /d:sonar.host.url="https://sonarcloud.io" /d:sonar.verbose=true /d:sonar.login=${SONAR_TOKEN}
echo "Running build..."
dotnet build ./src/ADN.Net/
dotnet build ./tests/ADN.Net.Tests/
echo "Running tests..."
dotnet test ./tests/ADN.Net.Tests/ /p:CollectCoverage=true /p:CoverletOutputFormat=opencover
echo "Executing MSBuild DLL end command..."
dotnet ./tools/sonar/SonarScanner.MSBuild.dll end /d:sonar.login=${SONAR_TOKEN}
