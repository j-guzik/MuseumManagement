# Museum Management


## Table of contents
* [Basic information](#basic-information)
* [Technologies](#technologies)
* [Setup](#setup)

## Basic information
Web application for .NET Core MVC. It is used to manage museum exhibits.
	
![](https://github.com/j-guzik/MuseumManagement/blob/master/video/MuseumManagement.gif)  

## Technologies
Project is created with:
* C#
* SQL
* HTML
* JS
* CSS

## Setup
To run this project you will need:
* Visual Studio 2019 
* ASP .NET Core 3.1

In the appsettings.json file, check also if you have a proper connection to your local sql server.

In the NuGet Package Manager you should also install:
* Microsoft.AspNetCore.Identity.EntityFrameworkCore 3.1.10
* Microsoft.AspNetCore.Identity.UI 3.1.10
* Microsoft.EntityFrameworkCore 3.1.10
* Microsoft.EntityFrameworkCore.Sqlite 3.1.10
* Microsoft.EntityFrameworkCore.SqlServer 3.1.10
* Microsoft.EntityFrameworkCore.Tools 3.1.10
* Microsoft.VisualStudio.Web.CodeGeneration.Design 3.1.4

To migrate data, open NPM console and type:
```
PM> Add-Migration nameMigration
PM> Update-Database
```
