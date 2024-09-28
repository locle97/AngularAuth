# Angular Authentication

## Requirements

- Authenticated user -> View Dashboard view
- Admin user -> View Accounts view
- JWT Token
    - HS256
    - RS256
- Token generation will be done in Backend .NET

## Non-functional requirements

- Availability 
- Latency: The login function should response ASAP
- Scalability

## Core entities

- User
    - Id
    - Name
    - Username
    - Password

- Role
    - Id
    - Code

- UserRole
    - Id
    - UserId
    - RoleId

## Public APIs

- POST /hs256/login -> JWT Token
body: {
    username,
    password
}

- POST /hs256/register -> 201
body: {
    name,
    username,
    password
}

- POST /rs256/login -> JWT Token
body: {
    username,
    password
}

- POST /rs256/register -> 201
body: {
    name,
    username,
    password
}

## Techstack

- Angular
- .NET core
- SQLite, EF Core
- Docker
- Azure
