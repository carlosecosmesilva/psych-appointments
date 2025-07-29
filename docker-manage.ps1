# PsychAppointments Docker Management Script

param(
    [Parameter(Mandatory=$false)]
    [ValidateSet("up", "down", "build", "logs", "clean", "reset")]
    [string]$Action = "up"
)

Write-Host "PsychAppointments Docker Management" -ForegroundColor Green
Write-Host "===================================" -ForegroundColor Green

switch ($Action) {
    "up" {
        Write-Host "Starting all services..." -ForegroundColor Yellow
        docker-compose up -d
        Write-Host ""
        Write-Host "Services are starting up. Access points:" -ForegroundColor Green
        Write-Host "- Frontend: http://localhost:4200" -ForegroundColor Cyan
        Write-Host "- API: http://localhost:5000" -ForegroundColor Cyan
        Write-Host "- pgAdmin: http://localhost:5050" -ForegroundColor Cyan
        Write-Host "  (Email: admin@psychappointments.com, Password: admin123)" -ForegroundColor Gray
    }
    "down" {
        Write-Host "Stopping all services..." -ForegroundColor Yellow
        docker-compose down
    }
    "build" {
        Write-Host "Building and starting all services..." -ForegroundColor Yellow
        docker-compose up --build -d
        Write-Host ""
        Write-Host "Services built and started. Access points:" -ForegroundColor Green
        Write-Host "- Frontend: http://localhost:4200" -ForegroundColor Cyan
        Write-Host "- API: http://localhost:5000" -ForegroundColor Cyan
        Write-Host "- pgAdmin: http://localhost:5050" -ForegroundColor Cyan
    }
    "logs" {
        Write-Host "Showing logs for all services..." -ForegroundColor Yellow
        docker-compose logs -f
    }
    "clean" {
        Write-Host "Cleaning up Docker resources..." -ForegroundColor Yellow
        docker-compose down
        docker system prune -f
        Write-Host "Cleanup complete." -ForegroundColor Green
    }
    "reset" {
        Write-Host "Resetting everything (including database)..." -ForegroundColor Red
        $confirm = Read-Host "This will delete all data. Continue? (y/N)"
        if ($confirm -eq "y" -or $confirm -eq "Y") {
            docker-compose down -v
            docker system prune -f
            Write-Host "Reset complete." -ForegroundColor Green
        } else {
            Write-Host "Reset cancelled." -ForegroundColor Yellow
        }
    }
}

Write-Host ""
Write-Host "Available commands:" -ForegroundColor Gray
Write-Host "  .\docker-manage.ps1 up      - Start all services" -ForegroundColor Gray
Write-Host "  .\docker-manage.ps1 down    - Stop all services" -ForegroundColor Gray
Write-Host "  .\docker-manage.ps1 build   - Build and start all services" -ForegroundColor Gray
Write-Host "  .\docker-manage.ps1 logs    - Show logs" -ForegroundColor Gray
Write-Host "  .\docker-manage.ps1 clean   - Clean Docker resources" -ForegroundColor Gray
Write-Host "  .\docker-manage.ps1 reset   - Reset everything (deletes data)" -ForegroundColor Gray
