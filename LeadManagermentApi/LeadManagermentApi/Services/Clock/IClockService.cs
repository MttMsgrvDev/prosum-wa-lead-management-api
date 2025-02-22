namespace LeadManagermentApi.Services.Clock;

/// <summary>
/// Provides clock services.
/// </summary>
public interface IClockService
{

    /// <summary>
    /// Gets the current time in UTC.
    /// </summary>
    public DateTime UtcNow { get; }

}