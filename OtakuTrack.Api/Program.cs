using Microsoft.EntityFrameworkCore;
using OtakuTrack.Infrastructure.BdContext;
using OtakuTrack.Repositories.Implementations.LogError;
using OtakuTrack.Repositories.Interfaces.LogError;
using OtakuTrack.Services.Implementations.LogError;
using OtakuTrack.Services.Interfaces.LogError;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configura��o do DbContext com SQL Server
builder.Services.AddDbContext<OtakuContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

// Configurar reposit�rios
//builder.Services.AddScoped<IAnimeRepository, AnimeRepository>();
builder.Services.AddScoped<IErrorLogRepository, ErrorLogRepository>();

// Configurar servi�os
//builder.Services.AddScoped<IAnimeService, AnimeService>();
builder.Services.AddScoped<IErrorLogService, ErrorLogService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
