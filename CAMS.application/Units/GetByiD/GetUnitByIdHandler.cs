using CAMS.application.Abstractions.Persistence;
using CAMS.application.Common;
using CAMS.application.Common.Exceptions;
using CAMS.domain.Units;
using CAMS.domain.ValueValidationTypes;

namespace CAMS.application.Courses.GetById;

public class GetUnitByIdHandler
{
    private readonly IUnitRepository _unitRepository;

    public GetUnitByIdHandler(IUnitRepository unitRepository)
    {
        _unitRepository = unitRepository;
    }

    public async Task<Result<Unit>> Handle(GetUnitByIdQuery query)
    {
        try
        {
            var unit = await _unitRepository.GetUnitByIdAsync(UnitId.From(query.unitId));
            return unit is not null
                ? Result<Unit>.Success(unit)
                : Result<Unit>.Failure("Unit Not Found");

        }
        catch (Exception ex)
        {
            return ApplicationExceptionTranslator<Unit>.Translate(ex);
        }
    }
}