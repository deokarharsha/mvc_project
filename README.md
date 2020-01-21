# MVC with .netcore and MSSql Server
To run project:
  Database
    1. Open SSMS or Azure Data Studio.
    2. Create a database 
    3. Open https://github.com/deokarharsha/mvc_project/blob/master/db/employee.sql 
    4. run the queries
    5. check if crud_employee and crud_empInfo table exists
    6. Exec the Stored procedure and check for any errors.
  
  Project
    1. Install .Net Core 3.1 SDK.
    2. Download and install Visual Studio Code.
    3  Open project in Visual Studio Code
    4. Open "Models/EmployeeDataAccessLayer.cs"
    5. Add your connection string "string connectionString = HERE"
    6. open terminal press or "ctrl + `" in vscode  
    7. run commad "dotnet restore"
    7. press F5 and check if project 
