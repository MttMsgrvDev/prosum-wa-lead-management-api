using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LeadManagermentApi.Data.Models;

/// <summary>
/// Configuration class for the Lead Entity;
/// </summary>
public class LeadConfiguration : IEntityTypeConfiguration<Lead>
{
    /// <summary>
    /// Configures the lead entity type.
    /// </summary>
    /// <param name="builder">The entity builder.</param>
    public void Configure(EntityTypeBuilder<Lead> builder)
    {
        builder.HasOne(l => l.Contact)
            .WithMany()
            .HasForeignKey(l => l.ContactId)
            .IsRequired(true);
    }
}