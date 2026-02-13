using CAMS.application.Abstractions.Persistence;
using CAMS.application.Common;
using CAMS.application.Common.Exceptions;
using CAMS.domain.Units;
using CAMS.domain.ValueValidationTypes;
using ClassAttendanceManagementSystem.Lessons;

namespace CAMS.application.Courses.GetById;

public class GetLessonByIdHandler
{
    private readonly ILessonRepository _lessonRepository;

    public GetLessonByIdHandler(ILessonRepository lessonRepository)
    {
        _lessonRepository = lessonRepository;
    }

    public async Task<Result<Lesson>> Handle(GetLessonByIdQuery query)
    {
        try
        {
            var lesson = await _lessonRepository.GetLessonById(LessonId.From(query.lessonId));
            return lesson is not null
                ? Result<Lesson>.Success(lesson)
                : Result<Lesson>.Failure("Lesson Not Found");

        }
        catch (Exception ex)
        {
            return ApplicationExceptionTranslator<Lesson>.Translate(ex);
        }
    }
}