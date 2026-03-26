using System.Globalization;
using System.Reflection;
using Localized;
using ClassLibrary;

Console.WriteLine("--- Localization Reflection Example ---");



var myCar = new Car
{
    Brand = "Tesla",
    Model = "Model S",
    Year = 2024,
    Color = "Red"
};

LogLocalizedProperties(myCar, "en-US");
Console.WriteLine();
LogLocalizedProperties(myCar, "nl");

Console.WriteLine("------------------------------------------");

static void LogLocalizedProperties(object obj, string cultureName)
{
    var culture = new CultureInfo(cultureName);
    CultureInfo.CurrentUICulture = culture;

    var type = obj.GetType();
    var classAttr = type.GetCustomAttribute<LocalizationInfoAttribute>();
    var className = classAttr?.GetLocalizedName() ?? type.Name;

    Console.WriteLine($"[Culture: {culture.Name}]");
    Console.WriteLine($"Class: {className}");

    var properties = type.GetProperties();
    foreach (var prop in properties)
    {
        var attr = prop.GetCustomAttribute<LocalizationInfoAttribute>();
        if (attr != null)
        {
            var localizedName = attr.GetLocalizedName() ?? prop.Name;
            var value = prop.GetValue(obj);
            Console.WriteLine($" - {localizedName}: {value}");
        }
    }
}
