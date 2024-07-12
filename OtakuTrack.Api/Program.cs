using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using OtakuTrack.Infrastructure.BdContext;
using OtakuTrack.Infrastructure.Mapping;
using OtakuTrack.Repositories.Implementations;
using OtakuTrack.Repositories.Implementations.LogError;
using OtakuTrack.Repositories.Interfaces;
using OtakuTrack.Repositories.Interfaces.LogError;
using OtakuTrack.Services.Implementations;
using OtakuTrack.Services.Implementations.LogError;
using OtakuTrack.Services.Interfaces;
using OtakuTrack.Services.Interfaces.LogError;

var builder = WebApplication.CreateBuilder(args);


// Configura��o do DbContext com SQL Server
builder.Services.AddDbContext<OtakuContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddAutoMapper(typeof(MappingProfile)); // Adiciona AutoMapper e registra seus perfis de mapeamento

// Configurar reposit�rios
builder.Services.AddScoped<IAnimeRepository, AnimeRepository>();
builder.Services.AddScoped<IErrorLogRepository, ErrorLogRepository>();

// Configurar servi�os
builder.Services.AddScoped<IAnimeService, AnimeService>();
builder.Services.AddScoped<IErrorLogService, ErrorLogService>();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configura��o do Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Otakutrack", Version = "v1" });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Otaku Track v1"));

}

// Configura��o do roteamento e autoriza��o
app.UseRouting();
app.UseAuthorization();

// Configura��o dos endpoints
app.MapControllers();

app.Run();
