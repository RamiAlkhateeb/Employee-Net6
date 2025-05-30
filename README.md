# Employees CRUD Web API with SignalR and Auth

This is upgraded from .NET 6 to .NET 9

As part of your technical assessment, you are requested to submit a working web application for a
Simple Employee CRUD solution:
1. Frontend (using Angular 13+)
2. Backend service (using .NET core 5+)
3. Database (MSSQL 2014+)
4. JWT authentication
5. API gateway


The solution should satisfy the following Design/Implementation considerations
- Create, Update and Delete requests should be implemented asynchronously.
- All API calls should be secure and authenticated.
- A Swagger endpoint with the API documentation should be provided.
- All backend configurations must be stored in the appsettings.json file and not hardcoded.
- Unit tests for the implemented functionalities.
The solution may have the following as a plus
- SignalR clients’ connections are authenticated using Bearer tokens so that notifications can be
sent to all clients’ connections opened by specific username.
- Use lazy loading in the frontend application in some capacity.
- Providing docker files for the frontend and backend projects
The criteria of the evaluation are:
- Covering the above technical requirements
- Working successfully
- Applying best practices
- Clean code
