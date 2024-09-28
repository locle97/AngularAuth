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

## Create Token in .NET

### Prerequisite

- System.IdentityModel.Tokens.Jwt

```bash
dotnet add package System.IdentityModel.Tokens.Jwt
```

### Steps

1. Create SymmetricSecurityKey

- SymmetricKey is the token key where sender and reciever have the same.
```csharp
var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("your_secret_key"));
```

2. Create credentials

- Using the key to generate credential
```csharp
var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
```

3. Building payload

```csharp
    var payload = new JwtSecurityToken(
            issuer: "my_issuer",
            audience: "your_audience",
            claims: new List<Claim>()
            {
                new Claim("username", user.Username),
            },
            expires: DateTime.Now.AddMinutes(30),
            signingCredentials: credentials
        )
```
4. Combine all together

- Combine header, payload and signature
    - header: which type of jwt token?
    - payload: the content of token, contains multiple claim
    - signature: generated credential

```csharp
return new JwtSecurityTokenHandler().WriteToken(payload);
```
