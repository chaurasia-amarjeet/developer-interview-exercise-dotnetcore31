# developer-interview-exercise-dotnetcore31
Developer interview exercise solution in .NET Core 3.1

Upgraded existing .NET 4.7.2 projects(https://github.com/chaurasia-amarjeet/developer-interview-exercise-dotnet472) into .NET Core 3.1

Since the project was small, We converted csproj file for each project manually to SDK format and targeted framework to .NET Core 3.1

Below are few tips while you convert your existing .NET 4.7.2 projects into .NET Core

1. Start with project which is not dependent on any other project and move deeper one after other.
2. Since .net core libraries contains most of system related references, you don't have to add them again in package reference.
3. Add remaining referneces to csproj file by referring packages.config file and building iteratively.
4. For test project add reference for "Microsoft.NET.Test.Sdk" & "NUnit3TestAdapter" in order to run tests using nunit apart from nunit/moq reference.
5. You can reachout to me using contacts details in profile for any help.

There are tools available in case you don't want to convert your csproj manually into SDK type. But for small projects like this I would recommend to do it manually, you will learn more about csproj file.

References: 
1. https://stackoverflow.com/questions/58067997/how-to-migrate-net-framework-4-7-2-project-to-net-core-3-0-in-visual-studio-20
2. https://docs.nunit.org/articles/nunit/getting-started/dotnet-core-and-dotnet-standard.html
3. https://docs.microsoft.com/en-us/dotnet/core/testing/unit-testing-with-nunit
4. https://medium.com/c-sharp-progarmming/migrate-net-framework-to-net-core-66746acb4092
