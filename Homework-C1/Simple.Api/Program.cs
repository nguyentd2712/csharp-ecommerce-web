using Microsoft.AspNetCore.Builder;
using System.Collections.Generic;

// Define the data record
public record dataDto(int Id, string Title, string Genre, decimal Price, DateOnly ReleaseDate);


internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllers();

        var app = builder.Build();

        // Define the static data list
        List<dataDto> dataList = [
            new (1, "Book One", "Fiction", 15.99M, new DateOnly(2020, 1, 15)),
            new (2, "Book Two", "Non-Fiction", 20.99M, new DateOnly(2019, 5, 23)),
            new (3, "Book Three", "Science Fiction", 25.99M, new DateOnly(2021, 3, 10)),
            new (4, "Book Four", "Fantasy", 30.99M, new DateOnly(2018, 7, 19)),
            new (5, "Book Five", "Mystery", 18.99M, new DateOnly(2022, 11, 5)),
            new (6, "Book Six", "Thriller", 22.99M, new DateOnly(2020, 9, 30)),
            new (7, "Book Seven", "Romance", 19.99M, new DateOnly(2017, 2, 14)),
            new (8, "Book Eight", "Fiction", 24.99M, new DateOnly(2021, 6, 21)),
            new (9, "Book Nine", "Non-Fiction", 29.99M, new DateOnly(2019, 12, 1)),
            new (10, "Book Ten", "Science Fiction", 34.99M, new DateOnly(2023, 4, 18))
        ];

        // Define the GET all data
        app.MapGet("/api/data", () => dataList);
        
        //Define the GET by id
        app.MapGet("/api/data/{id}", (int id) => dataList.Find(data => data.Id == id));

        app.Run();
    }
}

