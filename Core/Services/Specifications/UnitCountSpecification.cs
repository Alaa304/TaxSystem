using Core.Domain.Entities;
using Shared;

namespace Services.Specifications;

internal class UnitCountSpecification : BaseSpecifications<Unit, int>
{
    public UnitCountSpecification(UnitSpecificationParameters parameters)
        : base(u =>
            (!parameters.PropertyId.HasValue || u.PropertyId == parameters.PropertyId) &&
            (!parameters.UsageType.HasValue || u.UsageType == parameters.UsageType) &&
            (!parameters.Status.HasValue || u.Status == parameters.Status) &&
            (string.IsNullOrEmpty(parameters.Search) ||
             u.UnitNumber.ToLower().Contains(parameters.Search.ToLower()) ||
             u.Property.CurrentPropertyNo.ToLower().Contains(parameters.Search.ToLower()))
        )
    {
        AddInclude(u => u.Property);
    }
}
