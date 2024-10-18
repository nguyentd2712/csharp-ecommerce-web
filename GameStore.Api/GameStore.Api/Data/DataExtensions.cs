using System;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Api.Data;

public static class DataExtensions
{
    // public static void MigrateDb(this WebApplication app)
    // {
    //     using var scope =  app.Services.CreateScope();

    //     var DbContext = scope.ServiceProvider.GetRequiredService<GameStoreContext>();

    //     DbContext.Database.Migrate();

    // }

    //When applying Async should change the void -> async Task & MigrateAsync
    public static async Task MigrateDbAsync (this WebApplication app)
    {
        using var scope =  app.Services.CreateScope();

        var DbContext = scope.ServiceProvider.GetRequiredService<GameStoreContext>();

        await DbContext.Database.MigrateAsync();
        
    }
}
