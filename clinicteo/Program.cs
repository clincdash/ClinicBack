using clinicteo.Context;
using clinicteo.Models.User.Mapper;
using clinicteo.Services;
using clinicteo.UnitOfWork;
using clinicteo.UnitOfWork.Repositories;
using clinicteo.UnitOfWork.Repositories.impl;
using EvolveDb;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder( args );

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped< ClinicService >();
builder.Services.AddScoped< ClinicTeoContext >();
builder.Services.AddScoped( typeof( IRepositoryGeneric<> ), typeof( GenericRepository<> ));
builder.Services.AddScoped< RepositoryUoW >();
builder.Services.AddAutoMapper( typeof( UserMapperProfile ) );

var postgreURL = "TeoIrado";
var connection = builder.Configuration.GetConnectionString( postgreURL );
builder.Services.AddEntityFrameworkNpgsql().AddDbContext<ClinicTeoContext>( option => option.UseNpgsql( connection ) );

if (builder.Environment.IsDevelopment())
{
    try
    {
        var evolveConnection = new Npgsql.NpgsqlConnection( connection );
        var evolve = new Evolve( evolveConnection )
        {
            Locations = new List<string> { "Data/Migrations", "Data/Dataset" },
            IsEraseDisabled = true
        };
        evolve.Migrate();
    }
    catch (Exception exeption)
    {
        Console.WriteLine( exeption );
        throw;
    }
}

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