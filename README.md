# WorkoutTracker - Project

Ovo je implementacija .NET Web API projekta zasnovana WorkoutTracker.API, WorkoutTracker.Application, WorkoutTracker.Domain, WorkoutTracker.Infrastructure.

## Tehnologije
- **Runtime:** .NET 10
- **Baza podataka:** PostgreSQL
- **Autentifikacija:** JWT (JSON Web Token)
- **ORM:** Entity Framework Core

## Brzo pokretanje

### Projekat koristi PostgreSQL. Da biste pokrenuli bazu:
1. Proverite da li je PostgreSQL servis pokrenut.
2. Fajl `appsettingsExample.json` zameniti sa `appsettings.json` i podesite vaš Connection String:
   ```json
   "ConnectionStrings": {
     "DefaultConnection": "Host=localhost;Port=5432;Database=TvojDb;Username=postgres;Password=tvoja_sifra"
   }
3. Pokrenite migracije iz terminala:
    dotnet ef database update --project WorkoutTracker.Infrastructure --startup-project WorkoutTracker.API
### JWT
1. Za Jwt takodje podesite parametre u `appsettings.json`.

### Pokretanje aplikacije
1. Za pokretanje aplikacije iz WorkoutTracker.API foldera pokrenuti komandu `dotnet run`
2. Aplikacija ce biti pokrenuta na http://localhost:5086
