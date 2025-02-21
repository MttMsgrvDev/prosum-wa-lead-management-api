using LeadManagermentApi.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace LeadManagermentApi.Data.Context;

/// <summary>
/// The database contact for lead management.
/// </summary>
public class LeadContext : DbContext
{

    /// <summary>
    /// The lead records.
    /// </summary>
    public DbSet<Lead> Leads { get; set; }

    /// <summary>
    /// The contact records.
    /// </summary>
    public DbSet<Contact> Contacts { get; set; }


}