using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
//using HeroAPI.Data;
using HeroAPI.Models;
using HeroAPI.Data;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<HeroAPIContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("HeroAPIContext")));

/*
builder.Services.AddDbContext<HeroAPIContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("HeroAPIContext")));
*/
/*
builder.Services.AddDbContext<HeroAPIContext>(opt =>
    opt.UseInMemoryDatabase("Hero"));
*/

// Add services to the container.

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
