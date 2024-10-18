using System;
using GameStore.Api.Data;
using GameStore.Api.Dtos;
using GameStore.Api.Entities;
using GameStore.Api.Mapping;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Api.Endpoints;

public static class GamesEndpoints
{
    const string GetGameEndpointName = "GetGame";

    // private static readonly List<GameSummaryDto> games = [
    // new (1,
    //     "Street Fighter II", 
    //     "Fighting", 
    //     19.99M, 
    //     new DateOnly(2010,9,30)),
    // new (2,
    //     "Final Fantasy XIV",
    //     "Roleplaying", 
    //     59.99M, 
    //     new DateOnly(2010,9,30)),
    // new (3, 
    //     "FIFA 23", 
    //     "Sports", 
    //     69.99M, 
    //     new DateOnly(2022,9,27))
    // ];

    public static RouteGroupBuilder MapGamesEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("games");

        //Get /games
        // group.MapGet("/", () => games);
        group.MapGet("/", async (GameStoreContext dbContext) => 
           await  dbContext.Games
                        .Include(game => game.Genre)
                       .Select(game => game.ToGameSummaryDto()) 
                       .AsNoTracking()       //tell no need to tracking
                        .ToListAsync()      //Async to await
        );


        //app.MapGet("/", () => "Hello World!");

        //Get /games/1
        // group.MapGet("/{id}", (int id) =>
        group.MapGet("/{id}", async (int id, GameStoreContext dbContext) =>
        {
            // GameDto? game = games.Find(game => game.Id == id);
            // Game? game = dbContext.Games.Find(id); //if use async , replace by code below
            Game? game = await dbContext.Games.FindAsync(id);

            //check if not found should return 404 not found in response

            return game is null ? 
            Results.NotFound() : Results.Ok(game.ToGameDetailsDto());

        })
            .WithName(GetGameEndpointName);



        //POST /games
        group.MapPost("/", async (CreateGameDto newGame, GameStoreContext dbContext) =>
        {
            //use if is not good, define the [Required] và validation in the record class

            // if (string.IsNullOrEmpty(newGame.Name)){
            //     return Results.BadRequest("Name is required.");
            // }
            Game game = newGame.ToEntity();
           // game.Genre = dbContext.Genres.Find(newGame.GenreId); 

            // Game game = new(){
            //     Name = newGame.Name,
            //     Genre = dbContext.Genres.Find(newGame.GenreId),
            //     GenreId = newGame.GenreId,
            //     Price = newGame.Price,
            //     ReleaseDate = newGame.ReleaseDate
            // };

            // GameDto game = new(
            //     games.Count + 1,
            //     newGame.Name,
            //     newGame.Genre,
            //     newGame.Price,
            //     newGame.ReleaseDate
            // );

            // games.Add(game); Not use this line anymore, use below instead

                dbContext.Games.Add(game); //this line can remove Games, but still work well

                await  dbContext.SaveChangesAsync();


                // GameDto gameDto = new(
                //     game.Id,
                //     game.Name,
                //     game.Genre!.Name, //! says should not null
                //     game.Price,
                //     game.ReleaseDate
                // );

            // return Results.CreatedAtRoute(GetGameEndpointName, new { id = game.Id }, gameDto);
            return Results.CreatedAtRoute(
                GetGameEndpointName, 
                new { id = game.Id }, 
                game.ToGameDetailsDto());

        });
         //   .WithParameterValidation();


        //PUT /games
        group.MapPut("/{id}", async (int id, UpdateGameDto updatedGame, GameStoreContext dbContext) =>
        {
            // var index = games.FindIndex(game => game.Id == id);
            // var existingGame = dbContext.Games.Find(id); //if use async
            var existingGame = await dbContext.Games.FindAsync(id);

            //Check if the index is non-exist, return Not found in Response
            // if (index == -1)
            if(existingGame is null)
            {
                return Results.NotFound();
            }

            // games[index] = new GameSummaryDto(
            //     id,
            //     updateGame.Name,
            //     updateGame.Genre,
            //     updateGame.Price,
            //     updateGame.ReleaseDate
            // );

            dbContext.Entry(existingGame)
                .CurrentValues
                .SetValues(updatedGame.ToEntity(id));

            dbContext.SaveChanges();// if use asyn try replace by code below
            await dbContext.SaveChangesAsync();

            return Results.NoContent();
        });

        //DELETE /games/id
        // group.MapDelete("/{id}", (int id) =>
        // {   

        //     games.RemoveAll(game => game.Id == id);

        //     return Results.NoContent();
        // }
        // );

        group.MapDelete("/{id}", async (int id, GameStoreContext dbContext) =>
        {
            //FirstOrDefault is used to find the game with the specified id.
            // var game = games.FirstOrDefault(game => game.Id == id);
            // if (game == null)
            // {
            //     return Results.NotFound();
            // }

            // games.Remove(game);

            await  dbContext.Games.Where(game => game.Id == id)
                    .ExecuteDeleteAsync();
            
            return Results.NoContent();
        });


        return group;
    }














}
