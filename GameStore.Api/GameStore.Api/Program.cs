using GameStore.Api.Data;
using GameStore.Api.Dtos;
using GameStore.Api.Endpoints;

var builder = WebApplication.CreateBuilder(args);

// var connString = "Data Source=GameStore.db";
var connString = builder.Configuration.GetConnectionString("GameStore");

builder.Services.AddSqlite<GameStoreContext>(connString);

var app = builder.Build();

// const string GetGameEndpointName = "GetGame";

// List<GameDto> games = [
// new (1,"Street Fighter II", "Fighting", 19.99M, new DateOnly(2010,9,30)),
// new (2,"Final Fantasy XIV","Roleplaying", 59.99M, new DateOnly(2010,9,30)),
// new (3, "FIFA 23", "Sports", 69.99M, new DateOnly(2022,9,27))
// ];

// //Get /games
// app.MapGet("games", () => games);

// //app.MapGet("/", () => "Hello World!");

// //Get /games/1
// app.MapGet("games/{id}", (int id) =>
// {
//     GameDto? game = games.Find(game => game.Id == id);

//     //check if not found should return 404 not found in response

//     return game is null ? Results.NotFound() : Results.Ok(game);

// })
//     .WithName(GetGameEndpointName)
// ;

// //POST /games
// app.MapPost("games", (CreateGameDto newGame) =>
// {
//     GameDto game = new(
//         games.Count + 1,
//         newGame.Name,
//         newGame.Genre,
//         newGame.Price,
//         newGame.ReleaseDate
//     );

//     games.Add(game);

//     return Results.CreatedAtRoute(GetGameEndpointName, new { id = game.Id }, game);

// });


// //PUT /games
// app.MapPut("games/{id}", (int id, UpdateGameDto updateGame) =>
// {
//     var index = games.FindIndex(game => game.Id == id);

// //Check if the index is non-exist, return Not found in Response
//     if (index == -1)
//     {
//         return Results.NotFound();
//     }

//     games[index] = new GameDto(
//         id,
//         updateGame.Name,
//         updateGame.Genre,
//         updateGame.Price,
//         updateGame.ReleaseDate
//     );

//     return Results.NoContent();
// });

// //DELETE /games/id
// app.MapDelete("games/{id}", (int id) =>
// {
//     games.RemoveAll(game => game.Id == id);

//     return Results.NoContent();
// }
// );

// app.MigrateDb();  //after applying Async , should change the code as below
await app.MigrateDbAsync();

app.MapGamesEndpoints();

app.MapGenresEndpoints();

app.Run();
