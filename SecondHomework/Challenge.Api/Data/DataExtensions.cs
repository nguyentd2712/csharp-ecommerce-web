using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Challenge.Api.Data;

public static class DataExtensions
{
        public static void MigrateDb(this WebApplication app)
    {
        using var scope =  app.Services.CreateScope();

        var DbContext = scope.ServiceProvider.GetRequiredService<CategoryContext>();

        DbContext.Database.Migrate();

    }

}