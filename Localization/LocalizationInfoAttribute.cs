namespace Localized;

[AttributeUsage(AttributeTargets.All)]
public class LocalizationInfoAttribute : Attribute
{
    public string ResourceKey { get; }

    public LocalizationInfoAttribute(string resourceKey)
    {
        ResourceKey = resourceKey;
    }

    public string? GetLocalizedName()
    {
        return Strings.ResourceManager.GetString(ResourceKey);
    }
}
