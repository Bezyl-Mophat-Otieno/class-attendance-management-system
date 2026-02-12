using CAMS.application.Abstractions.Persistence;
using CAMS.application.Common;
using CAMS.application.Common.Exceptions;
using CAMS.domain.Units;
using CAMS.domain.ValueValidationTypes;

namespace CAMS.application.Units.Create;

public class CreateUnitHandler
{
    private readonly IUnitRepository _unitRepository;
    public CreateUnitHandler(IUnitRepository unitRepository)
    {
        _unitRepository = unitRepository;
    }

    public async Task<Result<UnitId>> Handle(CreateUnitCommand command)
    {
        try
        {
            var unitName = UnitName.From(command.UnitName);
            var existingUnit = await _unitRepository.GetUnitByNameAsync(unitName);
            if (existingUnit is not null) return Result<UnitId>.Failure("Unit Already Exists");
            var unit = Unit.Create(
                unitName,
                UnitDuration.From(command.UnitDuration),
                CourseId.From(command.CourseId)
                );
            await _unitRepository.AddUnitAsync(unit);
            return Result<UnitId>.Success(unit.UnitId);
        }
        catch (Exception ex)
        {
            return ApplicationExceptionTranslator<UnitId>.Translate(ex);
        }

    }
}