# Syntrice Record Shop
![Animation](https://github.com/user-attachments/assets/16109bfc-107e-44a9-9e10-883b6d78a756)

## About

**Syntrice Recor Shop** is a full-stack web application built upon [ASP.NET](https://dotnet.microsoft.com/en-us/apps/aspnet). 
It consists of a backend RESTful API and a Dynamic Web Application, designed to be run as separate microservices. 

## Technologies

- **Language:** C#
- **Frameworks:** ASP.NET, Blazor (Web Assembly + Server Side Rendering)
- **Data Management:** Microsoft SQL Server, Entity Framework Core
- **Tools:** HttpClient, Automapper, Bulma.css
- **Testing:** NUnit, Moq, Fluent Assertions
- **General:** Dependency Injection, Layered Architecture, HTTP Request Handling,
  Repository-Service-Controller Pattern, Generics, Test Driven Development, Data Transfer Objects

## Setup

If you are running windows, the easiest way to build this solution is through Microsoft Visual Studio 2022. You will also need .NET 8.0 installed.

1. Clone the repository

```powershell
git clone "https://github.com/Syntrice/syntrice-contact-manager"
```

2. Navigate to repository root

```powershell
cd "./syntrice-contact-manager"
```

3. Restore dependencies

```powershell
dotnet restore
```

4. Build Project

```powershell
dotnet build "./ContactManager.sln"
```

As part of this process, you will also need to configure a sql server connection string. 
This can point to a locally installed SQL Server service, or any other location. 
You will need to apply a migration to this database to ensure that it is created.
Instructions on how to do this are coming soon!

## Licence

This project is licensed under the MIT License.
