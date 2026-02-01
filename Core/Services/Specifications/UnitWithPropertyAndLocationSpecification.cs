using Core.Domain.Entities;
using Shared;


namespace Services.Specifications;

internal class UnitWithPropertyAndLocationSpecification
    : BaseSpecifications<Unit, int>
{
    public UnitWithPropertyAndLocationSpecification(UnitSpecificationParameters parameters)
        : base(u =>
            (!parameters.PropertyId.HasValue || u.PropertyId == parameters.PropertyId) &&
            (!parameters.StreetId.HasValue || u.Property.StreetId == parameters.StreetId) &&
            (!parameters.GovernorateId.HasValue || u.Property.Street.ShaikhaId == parameters.GovernorateId) &&
            (!parameters.UsageType.HasValue || u.UsageType == parameters.UsageType) &&
            (!parameters.Status.HasValue || u.Status == parameters.Status) &&
            (string.IsNullOrEmpty(parameters.Search) ||
             u.UnitNumber.ToLower().Contains(parameters.Search.ToLower()) ||
             u.Property.CurrentPropertyNo.ToLower().Contains(parameters.Search.ToLower()))
        )
    {
        // Includes
        AddInclude(u => u.Property);
        AddInclude(u => u.Property.Street);
        AddInclude(u => u.Property.Street.Shaikha);

        // Sorting
        switch (parameters.Sort)
        {
            case UnitSortingOptions.AreaAsc:
                AddOrderBy(u => u.Area);
                break;

            case UnitSortingOptions.AreaDesc:
                AddOrderByDescending(u => u.Area);
                break;

            case UnitSortingOptions.FloorAsc:
                AddOrderBy(u => u.Floor);
                break;

            case UnitSortingOptions.FloorDesc:
                AddOrderByDescending(u => u.Floor);
                break;

            default:
                AddOrderBy(u => u.Id);
                break;
        }

        // Pagination
      //  ApplayPagination(parameters.PageSize, parameters.PageIndex);
    }

    // Single Unit Details
    public UnitWithPropertyAndLocationSpecification(int id)
        : base(u => u.Id == id)
    {
        AddInclude(u => u.Property);
        AddInclude(u => u.Property.Street);
        AddInclude(u => u.Property.Street.Shaikha);
        AddInclude(u => u.RoleAssignments);
    }
}
