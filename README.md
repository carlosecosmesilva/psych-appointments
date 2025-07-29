# 🧠 PsychAppointments

A modern, full-stack web application for managing psychology appointments and patient schedules. Built with ASP.NET Core Web API backend and Angular frontend, fully containerized with Docker.

[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)
[![.NET](https://img.shields.io/badge/.NET-9.0-purple.svg)](https://dotnet.microsoft.com/)
[![Angular](https://img.shields.io/badge/Angular-20-red.svg)](https://angular.io/)
[![PostgreSQL](https://img.shields.io/badge/PostgreSQL-15-blue.svg)](https://www.postgresql.org/)
[![Docker](https://img.shields.io/badge/Docker-Ready-2496ED.svg)](https://www.docker.com/)

## 🌟 Features

-   **Patient Management**: Complete patient profile management system
-   **Appointment Scheduling**: Advanced appointment booking and management
-   **User Roles**: Support for different user types (Admin, Psychologist, Patient)
-   **RESTful API**: Clean, well-documented API endpoints
-   **Modern UI**: Responsive Angular frontend with modern design
-   **Dockerized**: Complete containerization for easy deployment
-   **Database Management**: PostgreSQL with pgAdmin interface

## 🏗️ Architecture

```
┌─────────────────┐    ┌─────────────────┐
│   Angular App   │    │     pgAdmin     │
│   (Frontend)    │    │   (DB Admin)    │
└─────────────────┘    └─────────────────┘
         │                       │
         │ HTTP/REST             │ HTTP
         ▼                       ▼
┌─────────────────┐    ┌─────────────────┐
│  ASP.NET API    │────│   PostgreSQL    │
│   (Backend)     │    │   (Database)    │
└─────────────────┘    └─────────────────┘
```

### Technology Stack

**Backend:**

-   ASP.NET Core 9.0 Web API
-   Entity Framework Core with PostgreSQL
-   Clean Architecture (Domain, Application, Infrastructure layers)
-   Dependency Injection

**Frontend:**

-   Angular 20
-   TypeScript
-   Responsive design
-   Server-Side Rendering (SSR) ready

**Database:**

-   PostgreSQL 15
-   Entity Framework Core migrations
-   pgAdmin for database management

**DevOps:**

-   Docker & Docker Compose
-   Nginx for frontend serving
-   Multi-stage builds for optimization

## 🚀 Quick Start

### Prerequisites

-   [Docker Desktop](https://www.docker.com/products/docker-desktop)
-   [Git](https://git-scm.com/)

### Installation

1. **Clone the repository:**

    ```bash
    git clone https://github.com/yourusername/psych-appointments.git
    cd psych-appointments
    ```

2. **Start the application:**

    ```bash
    docker-compose up --build
    ```

3. **Access the applications:**
    - **Frontend**: http://localhost:4200
    - **API**: http://localhost:5000
    - **API Documentation**: http://localhost:5000/swagger
    - **pgAdmin**: http://localhost:5050
        - Email: `admin@psychappointments.com`
        - Password: `admin123`

### Development Setup

For development with hot reload:

```bash
# Start with development overrides
docker-compose -f docker-compose.yml -f docker-compose.override.yml up --build

# Or use the PowerShell script
.\docker-manage.ps1 build
```

## 📁 Project Structure

```
psych-appointments/
├── client/                          # Frontend Application
│   └── psych-appointments-client/
│       ├── src/
│       │   ├── app/                 # Angular components and services
│       │   ├── styles.scss          # Global styles
│       │   └── index.html           # Main HTML file
│       ├── Dockerfile               # Angular container config
│       └── nginx.conf               # Nginx configuration
├── server/                          # Backend Application
│   ├── PsychAppointments.WebApi/    # API layer
│   │   ├── Controllers/             # API controllers
│   │   ├── Program.cs               # Application entry point
│   │   └── appsettings.json         # Configuration
│   ├── PsychAppointments.Application/ # Application layer
│   │   ├── Interfaces/              # Service interfaces
│   │   └── UseCases/                # Business logic
│   ├── PsychAppointments.Domain/    # Domain layer
│   │   ├── Entities/                # Domain entities
│   │   └── Enums/                   # Domain enumerations
│   ├── PsychAppointments.Infrastructure/ # Infrastructure layer
│   │   ├── Data/                    # Database context
│   │   ├── Repositories/            # Data access
│   │   └── DependencyInjection/     # Service registration
│   └── Dockerfile                   # API container config
├── database/
│   └── init/                        # Database initialization scripts
├── docker-compose.yml               # Main Docker orchestration
├── docker-compose.override.yml      # Development overrides
└── DOCKER-README.md                 # Docker-specific documentation
```

## 🔧 Development

### Backend Development

The backend follows Clean Architecture principles:

-   **Domain Layer**: Core business entities and rules
-   **Application Layer**: Use cases and business logic
-   **Infrastructure Layer**: Data access and external services
-   **WebApi Layer**: HTTP endpoints and configuration

### Frontend Development

The Angular frontend provides:

-   Modular component architecture
-   Reactive forms for user input
-   HTTP client for API communication
-   Responsive design for all devices

### Database Schema

Key entities:

-   `User`: System users (Admin, Psychologist, Patient)
-   `Appointment`: Scheduled appointments
-   `Schedule`: Available time slots

## 🐳 Docker Management

Use the provided PowerShell script for easy Docker management:

```powershell
# Start all services
.\docker-manage.ps1 up

# Build and start
.\docker-manage.ps1 build

# View logs
.\docker-manage.ps1 logs

# Stop services
.\docker-manage.ps1 down

# Clean up
.\docker-manage.ps1 clean

# Reset everything (deletes data)
.\docker-manage.ps1 reset
```

## 🗄️ Database Management

### Connect to PostgreSQL via pgAdmin

1. Open pgAdmin at http://localhost:5050
2. Login with provided credentials
3. Add server connection:
    - **Name**: PsychAppointments
    - **Host**: postgres
    - **Port**: 5432
    - **Database**: PsychDb
    - **Username**: postgres
    - **Password**: postgres

### Entity Framework Migrations

```bash
# Add a new migration
dotnet ef migrations add MigrationName --project PsychAppointments.Infrastructure --startup-project PsychAppointments.WebApi

# Update database
dotnet ef database update --project PsychAppointments.Infrastructure --startup-project PsychAppointments.WebApi
```

## 🌐 API Documentation

The API includes Swagger documentation available at:

-   Development: http://localhost:5000/swagger
-   Production: Disabled by default for security

### Main Endpoints

-   `GET /api/users` - Get all users
-   `POST /api/users` - Create new user
-   `GET /api/appointments` - Get appointments
-   `POST /api/appointments` - Book appointment

## 🚀 Deployment

### Production Deployment

1. **Update environment variables:**

    ```bash
    cp .env.example .env
    # Edit .env with production values
    ```

2. **Deploy with Docker Compose:**

    ```bash
    docker-compose -f docker-compose.yml up -d
    ```

3. **Set up reverse proxy (recommended):**
    - Use nginx or traefik for SSL termination
    - Configure domain routing

### Environment Variables

Key environment variables for production:

```env
POSTGRES_DB=PsychDb
POSTGRES_USER=your_db_user
POSTGRES_PASSWORD=your_secure_password
PGADMIN_DEFAULT_EMAIL=admin@yourdomain.com
PGADMIN_DEFAULT_PASSWORD=your_secure_password
ASPNETCORE_ENVIRONMENT=Production
```

## 🤝 Contributing

1. Fork the repository
2. Create a feature branch (`git checkout -b feature/amazing-feature`)
3. Commit your changes (`git commit -m 'Add amazing feature'`)
4. Push to the branch (`git push origin feature/amazing-feature`)
5. Open a Pull Request

### Development Guidelines

-   Follow Clean Architecture principles
-   Write unit tests for new features
-   Use conventional commit messages
-   Update documentation as needed

## 📝 License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## 📞 Support

If you encounter any issues or have questions:

1. Check the [DOCKER-README.md](DOCKER-README.md) for Docker-specific help
2. Review the troubleshooting section in documentation
3. Open an issue on GitHub

## 🙏 Acknowledgments

-   Built with [ASP.NET Core](https://docs.microsoft.com/en-us/aspnet/core/)
-   Frontend powered by [Angular](https://angular.io/)
-   Database by [PostgreSQL](https://www.postgresql.org/)
-   Containerized with [Docker](https://www.docker.com/)

---

**Happy coding! 🚀**
