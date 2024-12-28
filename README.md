# Todo

# Project Documentation

## Solution Approach

The application is a Todos management system that allows authentication and authorization through a login mechanism. Users can log in by providing their username and password, and the system validates their credentials against the database.

The project is developed using **ASP.NET Core**, a **Clean Architecture** to structure the business logic, and **Entity Framework Core** for interaction with the database. The database is used to store the Todo and user details.

### Technologies used:
- **ASP.NET Core** for creating the RESTful API.
- **Entity Framework Core** for persisting data in the database.
- **SQL Server** as the database.
- **JWT** for authentication and authorization.

### Application Architecture:
- The application follows a **Clean Architecture**, separating responsibilities between layers:
- **Presentation Layer**: HTTP Controls (API Controllers).
- **Domain Layer**: Business Logic.
- **Infrastructure Layer**: Interaction with the database and inversion of control.
- **Services Layer**: Handling validation and authentication logic.

## Compliance with Requirements

The application meets the following requirements set by the company:

- **Authentication and Authorization**: A login system with user validation using username and password was implemented. Security is reinforced by validation against a database and the use of **JWT** for authorization on protected endpoints.

- **Interaction with the database**: Using **Entity Framework Core**, the application can access and manage Todo data efficiently.

- **Scalability**: The solution is designed to be scalable, using clean architecture practices and other clean code principles and best practices that allow for adding more functionality without compromising existing code.

- **Maintainability**: The application is designed for easy maintenance and extension. The modular architecture and separation of responsibilities allow for adding new features and making adjustments efficiently.

- **Unit Testing**: Unit testing was implemented to ensure the correct execution of the individual components of the application, ensuring that each module works in isolation and that the system as a whole meets the company's requirements.

- **Functionality**: The solution has several endpoints that allow the necessary operations to be performed for the Todo, ranging from its creation, update, change of status, acceptance of pending Todo and deletion, in addition to this it has security through JWT.

## Instructions for running and testing the application

### Prerequisites:
- **.NET 8.0**.
- **SQL Server** for the database.
- **Postman** to test the services.

### Project configuration:

1. **Clone the repository**:

Clone it using Git:

git clone (https://github.com/carlosriosdes/Todo.git)

2. **Configure connection string**:

configure the SqlConecctionTodoApp string in the appsettings.json file, it is important to have a login in SQL to be able to add it to the string

3. **Configure the database**:
Due to time issues I did not have time to do the crud for the states and users, but I leave evidence of how the tables should look, the fields can be entered through the SQL query editor.

the TodoStates table must contain the following information
IdTodoState Description
1 Todo
2 Doing
3 Done

the User table must contain at least one user to be able to access the application

IdUser Name Email UserName Password Role
1 Carlos carlos@gmail.com carlos carlos Admin

### Test the application:

1. **Run the application**:
* After running the application you will be able to view the available endpoints and you will be able to copy them to work with them in Postman.
* Run the login at endpoint /api/Auth/Login, this is to be able to access the token that allows you to consult the rest of the Todo actions.
* After having the Token, you can configure the rest of the endpoints for the Todo and consume them with the token that was generated in the previous step. It must be placed in the header with the key "Authorization" and in the value "Bearer (generated token)"

### Comments:

1. For the security issue such as the connection string or the key to generate the code, you can use security tools such as Azure's KeyVault so as not to have them hardcoded in the code, the same with the messages.
2. You could also add another level to the logs and leave them in a file or in the cloud also with Azure or another development platform
