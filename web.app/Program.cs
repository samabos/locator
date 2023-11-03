
using web.app.utilities;
using web.app.utilities.interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("appsettings.json");
builder.Logging.ClearProviders();
builder.Logging.AddConsole();
// Add services to the container.
builder.Services.AddRazorPages();

var environment = builder.Environment;
var csvFilePath = Path.Combine(environment.ContentRootPath, "data", "Data.csv"); // Get the CSV file path
builder.Services.AddSingleton<ICsvDataProvider>(provider =>
{
    var logger = provider.GetRequiredService<ILogger<CsvDataProvider>>();
    return new CsvDataProvider(csvFilePath, logger);
});

builder.Services.AddSingleton<IPayload, Payload>();
builder.Services.AddSingleton<IHaversine, Haversine>();
builder.Services.AddSingleton<IQuery, Query>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
