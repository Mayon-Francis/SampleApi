## Sample Api
This is a sample Api written using C# ASP.net WebApi

### Setup
- Create `.env` file with DB connection data according to `.env.example` file
- install dotnet ef cli tool `dotnet tool install --global dotnet-ef`
- cd to `SampleApi` folder and run
    - Update Migration folder if needed with `dotnet ef migrations add InitialCreate`
    - Run The migrations with `dotnet ef database update`

### To run locally
Note: the Database will need to be started separately
- cd to `SampleApi` folder and run
    - Install dependencies: `dotnet restore`
    - use `dotnet run` to run the server

### To run via docker compose
Note: this includes a postgres db alongside
- Run `docker compose up --build`