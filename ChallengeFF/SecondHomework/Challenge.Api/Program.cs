// using Challenge.Api.Dtos;
using Challenge.Api.Data;
using Challenge.Api.Endpoints;

// Add services to the container.
var builder = WebApplication.CreateBuilder(args);

var connString = builder.Configuration.GetConnectionString("ChallengeHomework");

builder.Services.AddSqlite<CategoryContext>(connString);

var app = builder.Build();

app.MigrateDb();

app.MapCategoriesEndpoints();

app.Run();
