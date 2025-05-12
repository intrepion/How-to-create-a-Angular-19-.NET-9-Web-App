using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;
using YoutubeDotNet9.Interfaces;
using YoutubeDotNet9.Models;
using YoutubeDotNet9.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<SampleDatabaseContext>(options =>
{
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddScoped<IPokemonRepository, PokemonRepository>();

builder.Services.AddCors(opt =>
{
    opt.AddPolicy(name: "CorsPolicy", builder =>
    {
        builder.WithOrigins("http://localhost:4200"/*, "www.url.com"*/)
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials();
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseCors("CorsPolicy");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
