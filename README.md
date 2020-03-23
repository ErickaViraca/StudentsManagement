# StudentsManagement
Code Exercise:  System to managing and searching for students, that will be used by high schools, elementary  schools, kindergardens.

## Prerequisites
To complete this sample you need the following:

- Visual Studio installed on your development machine.
- .Net Core SDK. (Note This project was written with .Net Core SDK 2.1)

## Build the project
To build, publish and generate the .exe file for solution project you need to execute the following commands:

```
	dotnet restore
	dotnet build
	dotnet publish -c Release -r win10-x64
```

## Execute the .exe file with commands
After execute all the previous commands, you must situate within bin\Release\netcoreapp2.1\win10-x64 and execute the commands according your needs.
First the .exe file, then the input.csv file that you want the console app read, after the parameters with their values.
for example:

```
	StudentsManagament.exe students.csv type=kinder
```

```cs
	StudentsManagament.exe students.csv name=Luke
```

```cs
	StudentsManagament.exe students.csv gender=M
```

Or by two parameters:

```cs
	StudentsManagament.exe students.csv gender=M type=university
```

```cs
	StudentsManagament.exe students.csv type=high gender=F
```