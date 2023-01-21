using Microsoft.EntityFrameworkCore;
using NavalWar.Business;
using NavalWar.DAL;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// EFCore Options
builder.Services.AddDbContext<NavalContext>(options => options.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=NavalWar_DB; Trusted_Connection = True; MultipleActiveResultSets = true "));

// Dependancies
builder.Services.AddScoped<IGameService>();

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
