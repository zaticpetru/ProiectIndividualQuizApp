# Backend App for QuizProject

## Adding migrations

To add a migration run:

`dotnet ef --startup-project QuizApp.Api/QuizApp.Api.csproj migrations add InitialModel -p QuizApp.Data/QuizApp.Data.csproj`

To apply migration on database run:

`dotnet ef --startup-project QuizApp.Api/QuizApp.Api.csproj database update`