using CAMS.application.Abstractions.Persistence;
using CAMS.domain.Units;
using CAMS.domain.ValueValidationTypes;
using CAMS.infrastructure.Persistence;
using CAMS.infrastructure.Persistence.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace ClassAttendanceManagementSystem.Persistence.Repositories;

public class UnitRepository : IUnitRepository
{
    private readonly AppDbContext _dbContext;

    public UnitRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;

    }
    public async Task AddUnitAsync(Unit unit)
    {
        try
        {
            await _dbContext.AddAsync(unit);
            await _dbContext.SaveChangesAsync();
        }
        catch (Exception e)
        {
            throw EfcoreExceptionTranslator.Translate(e);
        }
    }

    public async Task<Unit?> GetUnitByNameAsync(UnitName unitName)
    {
        try
        {
            return await _dbContext.Units.FirstOrDefaultAsync(u => u.UnitName == unitName);
        }
        catch (Exception e)
        {
            throw EfcoreExceptionTranslator.Translate(e);

        }
    }

    public async Task<Unit?> GetUnitByIdAsync(UnitId unitId)
    {
        try
        {
            return await _dbContext.Units.FindAsync(unitId);
        }
        catch (Exception e)
        {
            throw EfcoreExceptionTranslator.Translate(e);

        }

    }
}