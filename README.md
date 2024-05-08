# ConJob - .NET Core restful API

ConJob is a simple, pre-configured ASP.NET Core project designed to provide a starting point for building RESTful APIs following the three-tier architecture. It includes various features and configurations to help you quickly set up and develop your API, including authentication, authorization, error handling, and more.

## Features

- Three-Tier Architecture, using Class Libraries per tier
- DI-based, asynchronous services, returning generic response object
- JWT-based authentication and authorization
- Send email to verify the user's identity
- MD5 Hash Algorithm
- Middleware-based global error handling
- Restful API endpoints, returning DTOs and HTTP status codes
- Implementation of filtering, paging & sorting for API endpoint, which returns lists of objects
- Implementation of API endpoint versioning
- Entity Framework Core-based data access via POCO entities
- AutoMapper-based object-to-object mapping and database query optimization
- Security-focused configurability of database connection string and JWT-parameters via environment-based „appsettings.json“-files, secrets and/or environment variables
- Integration with AWS S3 for storing and retrieving files
- Chat and notification functionality integrated with Rocket.Chat for real-time communication

## Getting started

These instructions will get you a copy of the project up and running on your local machine for development and testing purposes. See deployment for notes on how to deploy the project on a live system.

### Prerequisites

- Visual Studio 2022 or higher
- .NET Core 8.x+ SDK
- SSMS (SQL Server Management Studio (SSMS) 20.x+)

### Setup

1. Clone this repository
2. At the root directory, restore required packages by running:

```
dotnet restore
```

3. Add a connection string and secret key in the `appsettings.json` or `appsettings.development.json` file. An example of the content of `example.appsettings.json` is shown in the following configuration:

```
"ConnectionStrings": {
  "DBContext": "Server=(localDB);Database=DB_ConJob;Trusted_Connection=True;MultipleActiveResultSets=true"
}
```

4. For development purposes, enable secret storage by running (If you're used to working with environment variables, fast forward to step 7):

```
dotnet user-secrets init
```

5. If you’re on Windows, goto and open `%APPDATA%\Microsoft\UserSecrets\<user_secrets_id>\secrets.json` file.
6. If you're on Linux/macOS, goto and open `~/.microsoft/usersecrets/<user_secrets_id>/secrets.json` file.
7. Within this secrets.json file, add the following lines to set your JWT-parameters:

```
"TokenSettings:Secret": "…"
```

#### (Optional) If you're not using secret storage, you can directly set your JWT parameters in the `appsettings.json` file. Open the `appsettings.json` or `appsettings.development.json` file and add the following lines:

```
"AppSettings": {
  "Secret": ""
}
```

8. For an Code-First Approach to creating the database, run the following command (make sure your current directory is `ConJob.Data`):

```
dotnet ef migrations add InitialCreate
```

9. Followed by:

```
dotnet ef database update
```

10. Next, build the solution by running:

```
dotnet build
```

11. Once done, launch the application by running:

```
dotnet run
```

12. Launch https://localhost:5288/swagger/index.html in your browser to view the Swagger documentation of your API

## Technologies

- .NET Core 8.3
- ASP.NET Core 8.3
- Entity Framework Core 8.3
- AutoMapper
- AWSSDK.S3
- Hangfile
- MailKit
- Asp.Versioning

## Contribution

We welcome contributions from the community. If you'd like to contribute to the project, please create a new issue or submit a pull request.
To contribute with this project:

- Do a fork of this repository;
- Create a branch with your feature: git checkout -b my-feature;
- Commit your changes: git commit -m 'feat: 'My feature details'.
- Push the commits to your branch git push origin my-feature.
- After the merge of your pull request has been made, you can delete your branch.
