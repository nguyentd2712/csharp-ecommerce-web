var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllers();

        var app = builder.Build();

        // Define the static data list
        List<homework.api.Categories> categoryList = [
            new (1, "Fiction"),
            new (2, "Non-Fiction"),
            new (3, "Science Fiction"),
            new (4, "Fantasy"),
            new (5, "Mystery"),
            new (6, "Thriller"),
            new (7, "Romance"),
            new (8, "Fiction"),
            new (9, "Non-Fiction"),
            new (10, "Science Fiction")
        ];

        // Define the GET all data
        app.MapGet("/api/category", () => categoryList);
        
        //Define the GET by id
        app.MapGet("/api/category/{id}", (int id) => categoryList.Find(data => data.Id == id));

        app.Run();
