# CampusEats (SE3090 Lab 11)

Full-stack app deployed across three cloud tiers.

| Tier | Folder | Host |
|------|--------|------|
| Frontend (React + Vite) | `campuseats-web/` | Vercel |
| Backend API (ASP.NET Core 8) | `CampusEats.Api/` | Render (Docker) |
| Database (PostgreSQL) | — | Neon |

## Environment variables (values are set on each platform, never committed)

| Tier | Variable | Purpose |
|------|----------|---------|
| Frontend | `VITE_API_URL` | Base URL of the deployed API |
| Backend | `ConnectionStrings__Default` | Neon PostgreSQL connection string (SSL Mode=Require) |
| Backend | `Jwt__Key` | Production JWT signing key |
| Backend | `Jwt__Issuer` / `Jwt__Audience` | `CampusEats` / `CampusEatsUsers` |
| Backend | `Cors__AllowedOrigins__0` | Deployed frontend origin, e.g. `https://campuseats-beta.vercel.app` |

## Run locally

```bash
# API (uses a local SQLite file in Development)
cd CampusEats.Api && dotnet run          # http://localhost:5074/swagger

# Frontend
cd campuseats-web
cp .env.example .env.local               # VITE_API_URL=http://localhost:5074
npm install && npm run dev               # http://localhost:5173
```
