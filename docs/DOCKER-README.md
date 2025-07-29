# PsychAppointments Docker Setup

This Docker Compose setup provides a complete containerized environment for the PsychAppointments application.

## Services

-   **PostgreSQL Database** (port 5432): Main database for the application
-   **pgAdmin** (port 5050): Web-based PostgreSQL administration tool
-   **ASP.NET Core Web API** (port 5000): Backend API service
-   **Angular Client** (port 4200): Frontend web application

## Prerequisites

-   Docker Desktop installed and running
-   Git (to clone the repository)

## Quick Start

1. Clone the repository:

    ```bash
    git clone <repository-url>
    cd psych-appointments
    ```

2. Create environment file (optional):

    ```bash
    cp .env.example .env
    ```

3. Build and start all services:

    ```bash
    docker-compose up --build
    ```

4. Access the applications:
    - **Frontend**: http://localhost:4200
    - **API**: http://localhost:5000
    - **pgAdmin**: http://localhost:5050
        - Email: admin@psychappointments.com
        - Password: admin123

## Development Commands

### Start all services

```bash
docker-compose up
```

### Start in background

```bash
docker-compose up -d
```

### Build and start (when code changes)

```bash
docker-compose up --build
```

### Stop all services

```bash
docker-compose down
```

### Stop and remove volumes (reset database)

```bash
docker-compose down -v
```

### View logs

```bash
docker-compose logs -f [service-name]
```

### Rebuild specific service

```bash
docker-compose build [service-name]
docker-compose up [service-name]
```

## Database Setup

### Connect to PostgreSQL via pgAdmin

1. Open pgAdmin at http://localhost:5050
2. Login with the credentials above
3. Add a new server connection:
    - **Name**: PsychAppointments
    - **Host**: postgres
    - **Port**: 5432
    - **Database**: PsychDb
    - **Username**: postgres
    - **Password**: postgres

### Run Entity Framework Migrations

If you need to run EF migrations, you can do so from the API container:

```bash
# Access the API container
docker-compose exec api bash

# Run migrations
dotnet ef database update
```

## Environment Variables

The following environment variables can be customized in the `.env` file:

-   `POSTGRES_DB`: Database name
-   `POSTGRES_USER`: Database username
-   `POSTGRES_PASSWORD`: Database password
-   `PGADMIN_DEFAULT_EMAIL`: pgAdmin login email
-   `PGADMIN_DEFAULT_PASSWORD`: pgAdmin login password

## Production Deployment

For production deployment:

1. Update the `.env` file with secure passwords
2. Consider using Docker secrets for sensitive data
3. Use a reverse proxy (nginx/traefik) for SSL termination
4. Set up proper backup strategies for the database volume

## Troubleshooting

### Port conflicts

If you have conflicts with the default ports, modify the port mappings in `docker-compose.yml`:

```yaml
ports:
    - "YOUR_PORT:CONTAINER_PORT"
```

### Database connection issues

-   Ensure PostgreSQL container is running: `docker-compose ps`
-   Check logs: `docker-compose logs postgres`
-   Verify connection string in API configuration

### Build issues

-   Clean Docker cache: `docker system prune -a`
-   Rebuild without cache: `docker-compose build --no-cache`

## Architecture

```
┌─────────────────┐    ┌─────────────────┐
│   Angular App   │    │     pgAdmin     │
│   (port 4200)   │    │   (port 5050)   │
└─────────────────┘    └─────────────────┘
         │                       │
         │ HTTP                  │ HTTP
         ▼                       ▼
┌─────────────────┐    ┌─────────────────┐
│  ASP.NET API    │────│   PostgreSQL    │
│  (port 5000)    │    │   (port 5432)   │
└─────────────────┘    └─────────────────┘
```

The Angular app communicates with the API, which in turn connects to PostgreSQL. pgAdmin provides a web interface for database management.
