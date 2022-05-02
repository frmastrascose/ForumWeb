# Forum Web Core 
Web App created using ASP.NET Core MVC for the challenge for FullStack Developer

#Instructions
* Checkou the project from Git
* Create a empty database named ForumWeb in your localDb in SQL SERVER
* Do a restore of the packages in the solutions and build the solution
* Go to Tools -> NuGet Packager Manager -> Package Manager Console and execute the command below to run the migrations and create the database structure: 
update-database
* Execute the application


## Details
The topic of project is discussion forum. 

Implemented:
* Adding posts, comments
* User Register
* User Login

DDD architecture:
* UI - Presentation Layer - ASP.NET Core MVC Project
* BBusiness - Business Logic Layer
* Infra - Data Access Layer

## Technologies: 
* ASP.NET Core MVC
* Bootstrap
* jQuery
* Identity Core
* Entity
