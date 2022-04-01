# Animal\_Shelter\_API

#### By _**S-Espinet**_

#### _C#/ASP.NET Core Web API tracking animals in a fictional database, using Swagger for documentation._ 

## Technologies Used

* _C#_
* _.NET5.0_
* _Microsoft Entity Framework Core_
* _SQL_
* _MySQL_
* _Swashbuckle.AspNetCore.Swagger_
* _Postman_
* _VisualStudio Code_

## Description

_This is a C# application that uses .NET and Entity to work with a SQL database to help a fictional bakery keep track of its treats and flavor options for those treats. It implements Swagger for documentation of the API's routes._

## GitHub Pages Link

* _N/A_

## Setup/Installation Requirements
### Prerequisites (things to have installed):
* _.NET Core 5.0_
* _MySQL Workbench_
* _Postman_
* _VisualStudio Code, or preferred code editor_

### Directions:
* _navigate to github.com/S-Espinet in browser_
* _select repository (AnimalShelter.Solution)_
* _click `Code` button and select desired security protocol_
* _run git clone in the terminal into desired directory_
* _run "dotnet restore" in the terminal from SweetAndSavory directory_
* _you may need to run the following commands in the terminal:_  
	* _dotnet add package Microsoft.EntityFrameworkCore -v 5.0.0_ 
	* _dotnet add package Pomelo.EntityFrameworkCore.MySql -v 5.0.0-alpha.2_ 
  	* _dotnet add package Microsoft.EntityFrameworkCore.Design -v 5.0.0_
* _create appsettings.json file; it should appear as follows:_   

~~~    
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft": "Warning",
      "Microsoft.Hosting.Lifetime": "Information"
    }
  },
  "AllowedHosts": "*",
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Port=3306;database=sarah_espinet;uid=root;pwd={YourPassword};"
  }
}  
~~~  

* _run "dotnet ef database update" to create your database_
* _create a .gitignore file to hold your appsettings.jsonfile and your bin, obj, and .vscode (if present) directories_
* _run "dotnet run" in terminal from AnimalShelter directory_
* _explore endpoints with Postman or your browser (http://localhost:5000/api/animals/{optional endpoint})_  

###Swagger
* _Swagger allows for documentation for API routes; to access run "dotnet run" in your termanial and navigate to http://localhost:5000/swagger_
* _You can click on any route type to see further notes, and use `Try it out` to explore endpoints in a manner similar to Postman_

###Endpoints
* Request Structure:
	* GET /api/animals
		* GET with sortMethod:
			* _api/animals?sortMethod=type_ -or-
			* _api/animals?sortMethod-gender_
	* Post /api/animals
	* GET /api/animals/{id}
## Known Bugs

* _This is not a real API_

## License

_[MIT](https://en.wikipedia.org/wiki/MIT_License)_

Copyright (c) _2022_ _S-Espinet_