using Challenge.Api.Dtos;
using Challenge.Api.Data;
using Challenge.Api.Endpoints;

// Add services to the container.
var builder = WebApplication.CreateBuilder(args);

// var connString = "Data Source=ChallengeHomework.db";
//connectionstring for ChallengeHomework defines in application.json
var connString = builder.Configuration.GetConnectionString("ChallengeHomework");

builder.Services.AddSqlite<CategoryContext>(connString);

var app = builder.Build();

// Define the static data list
// List<CategoriesDto> categoryList = [
//     new (1, "Fiction"),
//     new (2, "Non-Fiction"),
//     new (3, "Science Fiction"),
//     new (4, "Fantasy"),
//     new (5, "Mystery"),
//     new (6, "Thriller"),
//     new (7, "Romance"),
//     new (8, "Fiction"),
//     new (9, "Non-Fiction"),
//     new (10, "Science Fiction")
// ];

// Define the GET all data
// app.MapGet("/api/category", () => categoryList);

//Define the GET by id
// app.MapGet("/api/category/{id}", (int id) => categoryList.Find(data => data.Id == id));

app.MigrateDb();

app.MapCategoriesEndpoints();

app.Run();
