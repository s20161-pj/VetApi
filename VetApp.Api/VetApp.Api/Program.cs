
using Microsoft.EntityFrameworkCore;
using VetApp.Api.Context;
using VetApp.Repository.Interfaces;
using VetApp.Repository.Repository;
using VetApp.Services.Interfaces;
using VetApp.Services.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IVetService, VetService>();
builder.Services.AddScoped<IVetRepository, VetRepository>();
builder.Services.AddScoped<IClinicService, ClinicService>();
builder.Services.AddScoped<IClinicRepository, ClinicRepository>();
builder.Services.AddScoped<IVeterinaryVisitRepository, VeterinaryVisitRepository>();
builder.Services.AddScoped<IVeterinaryVisitService, VeterinaryVisitService>();
builder.Services.AddScoped<IClientRepository, ClientRepository>();
builder.Services.AddScoped<IClientService, ClientService>();
builder.Services.AddScoped<IPetRepository, PetRepository>();
builder.Services.AddScoped<IPetService, PetService>();
builder.Services.AddScoped<ISpecializationRepository, SpecializationRepository>();
builder.Services.AddScoped<ISpecializationService, SpecializationService>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddDbContext<MainContext>(options => 
    options.UseSqlite("DataSource=dbo.VetApp.db",
        sqlOptions => sqlOptions.MigrationsAssembly("VetApp.DataAccess")));
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