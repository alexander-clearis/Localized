using Localized;

namespace ClassLibrary;

[LocalizationInfo(nameof(Strings.Car))]
public class Car
{
    [LocalizationInfo(nameof(Strings.Brand))]
    public string Brand { get; set; } = string.Empty;

    [LocalizationInfo(nameof(Strings.Model))]
    public string Model { get; set; } = string.Empty;

    [LocalizationInfo(nameof(Strings.Year))]
    public int Year { get; set; }

    [LocalizationInfo(nameof(Strings.Color))]
    public string Color { get; set; } = string.Empty;
}
