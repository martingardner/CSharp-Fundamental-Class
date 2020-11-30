# CSharp-Fundamental-Class

gradebook is Scott Allen C# Fundamentals

- 'dotnet' base command
- for example, to run the GradeBook program, cd to /gradebook/src/GradeBook and run 'dotnet run' and it will run the program

## Dotnet Test

- 'note' gap in xunit lesson, need to add nuget.config file otherwise it will never find the nuget packages it needs
- test command 'dotnet test' inside folder

## Reference project

- for testing to work, needs to add reference to GradeBook
- from within GradeBook.Tests folder, added reference 'dotnet add reference ../../src/GradeBook/GradeBook.csproj'

## Solution file

- similar to a package.json command script for js
- new file `dotnet new sln`
- add a project to an sln file based on csproj files `dotnet sln add src/GradeBook/GradeBook.csproj` for example.

## Random

- snippet on how to check if a value is a positive integer for error handling
  https://docs.microsoft.com/en-us/dotnet/api/system.int32.tryparse?redirectedfrom=MSDN&view=net-5.0#System_Int32_TryParse_System_String_System_Int32__
