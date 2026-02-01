
namespace Shared;

public class UnitSpecificationParameters
{
    private const int defaultPageSize = 10;
    private const int maxPageSize = 50;

    // Location Filters
    public int? GovernorateId { get; set; }   // Shaikha Id
    public int? StreetId { get; set; }
    public int? PropertyId { get; set; }

    // Unit Filters
    public UsageType? UsageType { get; set; }
    public UnitStatus? Status { get; set; }

    // Search
    public string? Search { get; set; } // Unit Number or Property Number

    // Sorting
    public UnitSortingOptions? Sort { get; set; }

    // Pagination
    public int PageIndex { get; set; } = 1;

    private int _pageSize = defaultPageSize;
    public int PageSize
    {
        get => _pageSize;
        set => _pageSize = value > maxPageSize ? maxPageSize : value;
    }
}
