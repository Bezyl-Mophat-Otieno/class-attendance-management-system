using CAMS.domain.Units;
using CAMS.domain.ValueValidationTypes;

namespace CAMS.application.Abstractions.Persistence;

public interface IUnitRepository
{
    public Task AddUnitAsync(Unit unit);
    public Task<Unit?> GetUnitByNameAsync(UnitName unitName);

    public Task<Unit?> GetUnitByIdAsync(UnitId unitId);
}