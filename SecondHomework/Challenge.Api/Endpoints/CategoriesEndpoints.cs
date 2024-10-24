using System;
using System.Collections.Immutable;
using Challenge.Api.Data;
using Challenge.Api.Entities;
using Challenge.Api.Mapping;
using Microsoft.EntityFrameworkCore;

namespace Challenge.Api.Endpoints;

//Define endpoint Get
public static class CategoriesEndpoints
{
    public static RouteGroupBuilder MapCategoriesEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("");

        app.MapGet("/category", (CategoryContext dbContext) =>
             dbContext.Categories
                            .Select(category => category.ToDto())
                            .AsNoTracking()
                            .ToList()
    );

    

        app.MapGet("/category/{id}", (int id, CategoryContext dbContext) =>
            {
                Category? category = dbContext.Categories.Find(id); 

                return category is null ?
                Results.NotFound() : Results.Ok(category.ToDto());

            });

        return group;
    }
}