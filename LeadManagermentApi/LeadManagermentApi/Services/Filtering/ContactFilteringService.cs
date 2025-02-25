using LeadManagermentApi.Data.Models;
using LeadManagermentApi.DTOs;
using System.Linq.Expressions;

namespace LeadManagermentApi.Services.Filtering;

/// <summary>
/// Provides filtering services for contact entity records.
/// </summary>
public class ContactFilteringService : IFilteringService<Contact>
{
    /// <summary>
    /// Applies the filters to the query.
    /// </summary>
    /// <param name="query">The query to be executed.</param>
    /// <param name="filters">GThe filters to apply to the query.</param>
    /// <returns>The query with the applied filters.</returns>
    public IQueryable<Contact> Filter(IQueryable<Contact> query, FilterOptions filters)
    {
        var expressions = filters.Filters.Select(GetFilterPredicate);

        // TODO: IMPLEMENT!

        return query;
    }

    private Expression<Func<Contact, bool>> GetFilterPredicate(FieldFilter filter)
    {
        if (!string.Equals(filter.Oper, "=", StringComparison.OrdinalIgnoreCase))
        {
            throw new Exception($@"Invalid filter operator ""{filter.Oper}""");
        }

        switch (filter.Field)
        {
            case "Email":
                return c => c.Email == filter.Value.ToString();

            case "FirstName":
                return c => c.FirstName == filter.Value.ToString();

            case "LastName":
                return c => c.LastName == filter.Value.ToString();

            case "PhoneNumber":
                return c => c.PhoneNumber == filter.Value.ToString();

            case "ZipCode":
                return c => c.ZipCode == filter.Value.ToString();

            case "PermissionToContact":
                return c => c.PermissionToContact == (bool)filter.Value;

            default:
                throw new Exception($@"Unexpected property ""{filter.Field}""");
        }
    }
}