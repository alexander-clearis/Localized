using System.Reflection;
using System.Globalization;
using Microsoft.AspNetCore.Localization;
using ClassLibrary;
using Localized;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

var supportedCultures = new[] { "en-US", "nl" };
var localizationOptions = new RequestLocalizationOptions()
    .SetDefaultCulture(supportedCultures[0])
    .AddSupportedCultures(supportedCultures)
    .AddSupportedUICultures(supportedCultures);


    localizationOptions.RequestCultureProviders.Insert(0, new CustomRequestCultureProvider(context =>
{
    // Resolve culture from query string "lang" or header "X-Culture"
    var culture = context.Request.Headers["X-Culture"].ToString();

    if (string.IsNullOrEmpty(culture))
    {
        return Task.FromResult<ProviderCultureResult?>(null);
    }

    return Task.FromResult<ProviderCultureResult?>(new ProviderCultureResult(culture));
}));


app.UseRequestLocalization(localizationOptions);

app.MapGet("/car", () =>
{
    var car = new Car
    {
        Brand = "Tesla",
        Model = "Model 3",
        Year = 2024,
        Color = "Blue"
    };

    return Results.Ok(LocalizeObject(car));
});

app.Run();

static IDictionary<string, object?> LocalizeObject(object obj)
{
    var result = new Dictionary<string, object?>();
    var type = obj.GetType();
    var properties = type.GetProperties();

    foreach (var prop in properties)
    {
        var attr = prop.GetCustomAttribute<LocalizationInfoAttribute>();
        var key = attr?.GetLocalizedName() ?? prop.Name;
        var value = prop.GetValue(obj);
        Console.WriteLine($"[DEBUG_LOG] Localizing property {prop.Name} to {key} for culture {CultureInfo.CurrentUICulture.Name}");
        result[key] = value;
    }

    return result;
}
