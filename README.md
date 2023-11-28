# rental-car

## Getting Started

These instructions will help you set up and run the project on your local machine for development and testing purposes.

### Prerequisites

Make sure you have the following installed on your machine:

- Node.js and npm
- .NET Core SDK
- Angular CLI

### Installing

Run the following commands to install dependencies and set up the project:

```bash
# Install npm packages
npm install

# Delete Database
dotnet ef database drop -p Infrastructure -s API

# Delete Migrations
dotnet ef migrations remove -p Infrastructure -s API

# Create Migrations
dotnet ef migrations add InitialCreate -p Infrastructure -s API -o Data/Migrations

# Run the API (in the API folder)
dotnet watch --no-hot-reload
# When you run the API, test data will be passed to the SQLite database

# Run the client (in the Client folder)
ng serve

# When the project is finished, the SQLite will be transferred to PostgreSQL, for the production pass and the deployment of the app on the web.
