var builder = WebApplication.CreateBuilder(args);

var apiSettings = builder.Configuration.GetSection("ApiSettings");
var basehost = apiSettings.GetValue<string>("basehost");

if (basehost is null)
{
    throw new Exception("You forgot to set the host in appsettings.json");
}

builder.Services.AddHttpClient("GetCategory", client => { client.BaseAddress = new Uri(basehost); });

//Add service for controller to work on pages
builder.Services.AddRazorPages();

var app = builder.Build();

// to use the files in lib if wwwroot for styling
app.UseStaticFiles();
app.MapRazorPages();

app.Run();