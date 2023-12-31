using Abstractions.Repositories;
using Abstractions.Services;
using Data;
using Data.Repositories;
using Microsoft.EntityFrameworkCore;
using TestExercise.MappingProfiles;
using TestExercise.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<AppDbContext>(o => 
    o.UseSqlServer(builder.Configuration.GetConnectionString("default")));

builder.Services.AddScoped<IAccountRepository, AccountRepository>();
builder.Services.AddScoped<IContactRepository, ContactRepository>();
builder.Services.AddScoped<IIncidentRepository, IncidentRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddScoped<IChangerService, ChangerService>();
builder.Services.AddScoped<IFinderService, FinderService>();

builder.Services.AddAutoMapper(o => o.AddProfile<MappingProfile>());

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
