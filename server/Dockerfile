# Use the official .NET 9 SDK image for building
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build

# Set the working directory
WORKDIR /src

# Copy the solution file
COPY *.sln ./

# Copy all project files
COPY PsychAppointments.WebApi/*.csproj ./PsychAppointments.WebApi/
COPY PsychAppointments.Application/*.csproj ./PsychAppointments.Application/
COPY PsychAppointments.Domain/*.csproj ./PsychAppointments.Domain/
COPY PsychAppointments.Infrastructure/*.csproj ./PsychAppointments.Infrastructure/

# Restore dependencies
RUN dotnet restore

# Copy the entire source code
COPY . .

# Set working directory to the WebApi project
WORKDIR /src/PsychAppointments.WebApi

# Build the application
RUN dotnet build -c Release -o /app/build

# Publish the application
RUN dotnet publish -c Release -o /app/publish /p:UseAppHost=false

# Use the official .NET 9 runtime image for running
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime

# Set the working directory
WORKDIR /app

# Copy the published application from the build stage
COPY --from=build /app/publish .

# Expose the port the app runs on
EXPOSE 8080

# Set the entry point
ENTRYPOINT ["dotnet", "PsychAppointments.WebApi.dll"]
