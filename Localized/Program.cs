using System.Globalization;
using Localized;

// Set culture to en-US for the initial display
CultureInfo.CurrentUICulture = new CultureInfo("en-US");
Console.WriteLine($"Current culture: {CultureInfo.CurrentUICulture.Name}");
Console.WriteLine($"Original message: {Strings.Hello}");

// Change to nl
CultureInfo.CurrentUICulture = new CultureInfo("nl");
Console.WriteLine($"Changed culture to: {CultureInfo.CurrentUICulture.Name}");
Console.WriteLine($"Localized message: {Strings.Hello}");


