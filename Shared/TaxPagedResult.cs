namespace Shared;

public record TaxPagedResult<T>
(
    int PageIndex,
    int PageSize,
    int TotalCount,
    IEnumerable<T> Data
);
