
using LeadManagermentApi.DTOs;
using System.Text.RegularExpressions;

namespace LeadManagermentApi.Services.Filtering;

/// <summary>
/// Provides a set of filters from the query string params.
/// </summary>
/// <param name="contextAccessor">Provides access to the HTTP context.</param>
public class QueryStringFilterOptionsProvider(IHttpContextAccessor contextAccessor) : IFilterOptionsProvider
{
    public FilterOptions GetFilters()
    {
        var fieldFilters = new List<FieldFilter>();

        var queryStrings = contextAccessor.HttpContext?.Request.Query;

        if (null == queryStrings)
        {
            return new FilterOptions(fieldFilters);
        }

        foreach (var query in queryStrings)
        {
            var key = query.Key;

            if (!key.StartsWith("filter"))
            {
                continue;
            }

            var field = ParseFilterField(key);

            fieldFilters.Add(new FieldFilter(field, FieldFilterOperator.Equal, query.Value));
        }

        return new FilterOptions(fieldFilters);
    }

    private static string ParseFilterField(string filter)
    {
        var start = filter.IndexOf('[') + 1;
        var end = filter.IndexOf(']');

        return filter.Substring(start, end - start);
    }
}
