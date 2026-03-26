namespace Localized;

/// <summary>
/// Provides localization information for a member using a resource key.
/// </summary>
[AttributeUsage(AttributeTargets.All)]
public class LocalizationInfoAttribute : Attribute
{
    /// <summary>
    /// Gets the key used to retrieve the localized string from resources.
    /// </summary>
    public string ResourceKey { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="LocalizationInfoAttribute"/> class.
    /// </summary>
    /// <param name="resourceKey">The resource key to associate with the target member.</param>
    public LocalizationInfoAttribute(string resourceKey)
    {
        ResourceKey = resourceKey;
    }

    /// <summary>
    /// Retrieves the localized name from the global resource manager using the <see cref="ResourceKey"/>.
    /// </summary>
    /// <returns>The localized string if found; otherwise, <see langword="null"/>.</returns>
    public string? GetLocalizedName()
    {
        
        return Strings.ResourceManager.GetString(ResourceKey);
    }
}
