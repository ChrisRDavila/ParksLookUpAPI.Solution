# Parks Look Up API

#### _Chris Ross Davila_

#### This is an API project using C#/Dotnet. Clients can send a API call request to this project and retrieve data from data base with full CRUD functionality.  

## Technologies Used

* Git
* C#
* dotnet script(.NET 6.0 CLI)
* .NET
* Swagger
* RestSharp
* Entity Framework Core
* JSON Web Token Authentication
* MySQL Workbench
* VS code

## Description

* A user should be able to GET, POST, PUT and DELETE parks
* A user can choose between V1 and V2 version of ParksLookUpAPI.
* In API version v1, only basic CRUD functionality is deployed 
* In API version v2, user can search parkss by name, state , features, page and filter ratings above desire input level. User can search by any variation of the above parameters in unison or solo
* In v2 user can also look up random destinations

### Set Up and Run Project

1. Clone this repo.
2. Open the terminal and navigate to this project's production directory called "ParksLookUpAPI".
3. Within the production directory "ParksLookUpAPI", create two new files: `appsettings.json` and `appsettings.Development.json`.
4. Within `appsettings.json`, put in the following code. Make sure to replacing the `uid` and `pwd` values in the MySQL database connection string with your own username and password for MySQL. Also include desired value for `database` to create a new database later:

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*",
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Port=3306;database=[YOUR-DATA-BASE];uid=[YOUR-USER-HERE];pwd=[YOUR-PASSWORD];"
  }
}
```

5. Within `appsettings.Development.json`, add the following code:

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft": "Trace",
      "Microsoft.AspNetCore": "Information",
      "Microsoft.Hosting.Lifetime": "Information"
    }
  }
}
```

6. Create the database using the migrations in the ParksLookUpAPI project. Open your shell (e.g., Terminal or GitBash) to the production directory "ParksLookUpAPI", and run `dotnet ef database update`. 
7. Within the production directory "ParksLookUpAPI", run `dotnet watch run --launch-profile "ParksLookUpAPI-Production"` in the command line to start the project in production mode with a watcher. 
8. To optionally further build out this project in development mode, start the project with `dotnet watch run` in the production directory "ParksLookUpAPI".
9. Use your program of choice to make API calls. In your API calls, use the domain _http://localhost:5000_. Keep reading to learn about all of the available endpoints.

## Testing the API Endpoints

You are welcome to test this API via [Postman](https://www.postman.com/), or access the [Swagger UI](https://localhost:5001/swagger/index.html)  

### Available Endpoints

```
GET http://localhost:5000/api/{version}/parks/
POST http://localhost:5000/api/{version}/parks/
GET http://localhost:5000/api/{version}/parks/{id}
PUT http://localhost:5000/api/{version}/parks/{id}
DELETE http://localhost:5000/api/{version}/parks/{id}
GET http://localhost:5000/api/{v2}/parks/page/{page}
GET http://localhost:5000/api/{v2}/parks/random


```

Note: `{version}` is a version number and it should be replaced with a "v2" or "v1"; `{id}` is a variable and it should be replaced with the id number of the park data entry you want to GET, PUT or DELETE.

#### Optional Query String Parameters for GET Request

GET requests to `http://localhost:5000/api/{v2}/parks/` can optionally include query strings to filter or search parks.

| Parameter   | Type        |  Required    | Description |
| ----------- | ----------- | -----------  | ----------- |
| name        | String      | not required | Returns park name with a matching name value |
| state       | String      | not required | Returns park names with a matching state value |
| features    | String      | not required | Returns park names with a matching features value |
| filterRating  | Int32      | not required | Returns park names that have a rating value that is greater than or equal to the specified filterRating value |
| page  | Number      | not required | Returns park names contained in the 2 item page based on parameters given|

The following query will return a park with a name value of "Yellowstone":

```
GET http://localhost:5000/api/{v2}/parks?name=yellowstone
```

Example JSON response:
```json
{
  "parks": [
    {
      "parkId": 5,
      "name": "Yellowstone",
      "state": "Montana",
      "features": "Grand Prismatic",
      "rating": 6
    }
  ],
  "pageItems": 1,
  "currentPage": 1,
  "pageSize": 2
}
```

The following query will return all the park names with the state value of "Montana":


```
GET http://localhost:5000/api/{v2}/parks?state=montana
```
Example JSON response:
```json
{
  "parks": [
    {
      "parkId": 2,
      "name": "Glacier",
      "state": "Montana",
      "features": "The Sun Road",
      "rating": 9
    },
    {
      "parkId": 5,
      "name": "Yellowstone",
      "state": "Montana",
      "features": "Grand Prismatic",
      "rating": 6
    }
  ],
  "pageItems": 2,
  "currentPage": 1,
  "pageSize": 2
}
```

The following query will return all the park names with the features value of "Grand Prismatic":

```
GET http://localhost:5000/api/{v2}/parks?features=grand%20prismatic
```

Example JSON response:
```json
{
  "parks": [
    {
      "parkId": 5,
      "name": "Yellowstone",
      "state": "Montana",
      "features": "Grand Prismatic",
      "rating": 6
    }
  ],
  "pageItems": 1,
  "currentPage": 1,
  "pageSize": 2
}
```
The following query will return all park names with a rating of 3 or higher:

```
GET http://localhost:5000/api/{v2}/parks?filterRating=3
```

Example JSON response:
```json
{
  "parks": [
    {
      "parkId": 1,
      "name": "Zion",
      "state": "Utah",
      "features": "the Narrows",
      "rating": 8
    },
    {
      "parkId": 2,
      "name": "Glacier",
      "state": "Montana",
      "features": "The Sun Road",
      "rating": 9
    }
  ],
  "pageItems": 5,
  "currentPage": 1,
  "pageSize": 2
}
```
The following query will return all park destinations on page 2:

```
GET http://localhost:5000/api/{v2}/parks?page=2
```

Example JSON response:
```json
{
  "parks": [
    {
      "parkId": 3,
      "name": "Yosemite",
      "state": "California",
      "features": "Half Dome",
      "rating": 7
    },
    {
      "parkId": 4,
      "name": "The Grand Tetons",
      "state": "Wyoming",
      "features": "Jenny Lake",
      "rating": 7
    }
  ],
  "pageItems": 5,
  "currentPage": 2,
  "pageSize": 2
}
```

You can include multiple query strings by separating them with an `&`:

```
GET http://localhost:5000/api/{v2}/parks?state=montana&filterRating=4
```

#### Additional Requirements for POST Request

When making a POST request to `http://localhost:5000/api/{version}/parks/`, you need to include a **body** but exclude the parks `parkId` property. Here's an example body in JSON:

```json
{
  "name": "Yellowstone",
  "state": "Montana",
  "features": "Old Faithful",
  "rating": 5,
}
```

Notice that there there is no `parkId` property included as this property is Auto Incremented upon POST request

#### Additional Requirements for PUT Request

When making a PUT request to `http://localhost:5000/api/{version}/parks/{id}`, you need to include a **body** that includes the park's `parkId` property of a park that has already exists. Verification can be done through a GET all query or viewing the database in MySQL workbench. Here's an example body in JSON:

```json
{
  "parkId": 10,
  "name": "Yellowstone",
  "state": "Montana",
  "features": "Old Faithful",
  "rating": 5,
}
```

And here's the PUT request we would send the previous body to:

```
http://localhost:5000/api/{version}/parks/10
```

Notice that the value of `travelId` needs to match the id number in the URL. In this example, they are both 10.

## Known Bugs

* Does not have a one to many table connection with features to allow multiple features per park
* Does not have error handling to keep user from entering same park twice
* Does not have client based MVC to recieve API call and allow UI functionality 
* needs error handling to generate new POST or edit with PUT in place or previously DELETE'd entries

## License
[MIT](https://github.com/ChrisRDavila/ParksLookUpAPI.Solution/blob/main/License.txt)
Copyright (c) 2023 Christopher Ross Davila
