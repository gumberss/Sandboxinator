using Microsoft.AspNetCore.Authorization;
using Ocelot;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthentication();

builder.Services.AddSingleton<ITokenService>(new TokenService());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapPost("/validate", [AllowAnonymous] (UserValidationRequestModel request, HttpContext http, ITokenService tokenService) =>
{
    if (request is UserValidationRequestModel { UserName: "a", Password: "1" })
    {
        var token = tokenService.BuildToken(builder.Configuration["Jwt:Key"],
                                            builder.Configuration["Jwt:Issuer"],
                                            new[]
                                            {
                                                        builder.Configuration["Jwt:Aud1"],
                                                        builder.Configuration["Jwt:Aud2"]
                                                    },
                                            request.UserName);
        return new
        {
            Token = token,
            IsAuthenticated = true,
        };
    }
    return new
    {
        Token = string.Empty,
        IsAuthenticated = false
    };
})
.WithName("Validate");



app.Run();
