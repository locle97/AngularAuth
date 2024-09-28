using JwtAuth.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddInfrastructure();
builder.Services.AddServices();
builder.Services.AddCors();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(option =>
{
    option.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
});

app.UseHttpsRedirection();

app.MapPost("/login", async (LoginDto loginDto, IAuthService _authService) =>
{
    try
    {
        var token = await _authService.Auth(loginDto.Username, loginDto.Password);
        return Results.Ok(token);
    }
    catch (UnauthorizedAccessException)
    {
        return Results.Unauthorized();
    }


}).WithName("Login")
.WithOpenApi();

app.Run();

record LoginDto
{
    public required string Username { get; set; }
    public required string Password { get; set; }
}
