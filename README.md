## TecwiTask

### Requirements:
.NET Framework 4.7, SQL Server

### How-to Run
- Open solution in Visual Studio
- Open Web.config in Tecwi1 project directory and edit Database connection string with *DefaultConnection* name to specify SQL Server (default: .\SQLEXPRESS)
- Open Package Manger Console and run **update-database** script to init the database with data.
- Run project using IISExpress.
