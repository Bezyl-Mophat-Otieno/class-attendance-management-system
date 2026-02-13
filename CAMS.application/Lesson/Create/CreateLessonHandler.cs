using CAMS.application.Abstractions.Persistence;
using CAMS.application.Common;
using CAMS.application.Common.Exceptions;
using CAMS.application.Units.Create;
using CAMS.domain.ValueValidationTypes;
using ClassAttendanceManagementSystem.Lessons;

namespace CAMS.application.Lessons.Create;

public class CreateLessonHandler
{
    private readonly ILessonRepository _unitRepository;
    public CreateLessonHandler(ILessonRepository unitRepository)
    {
        _unitRepository = unitRepository;
    }

    public async Task<Result<LessonId>> Handle(CreateLessonCommand command)
    {
        try
        {
            var unit = Lesson.Create(
                UnitId.From(command.UnitID),
                command.StartDate,
                command.EndDate
                );
            await _unitRepository.AddLessonAsync(unit);
            return Result<LessonId>.Success(unit.LessonId);
        }
        catch (Exception ex)
        {
            return ApplicationExceptionTranslator<LessonId>.Translate(ex);
        }

    }
}