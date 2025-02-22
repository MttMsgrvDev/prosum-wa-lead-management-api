
namespace LeadManagermentApi.Services.Clock;

/// <summary>
/// Provides clock services.
/// </summary>
public class ClockService : IClockService
{
    /// <summary>
    /// Provides the current UTC time.
    /// </summary>
    public DateTime UtcNow => DateTime.UtcNow;
}