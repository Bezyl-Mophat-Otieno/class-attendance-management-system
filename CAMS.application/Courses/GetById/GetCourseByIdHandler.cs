using CAMS.application.Abstractions.Persistence;
using CAMS.application.Common;
using CAMS.application.Common.Exceptions;
using CAMS.domain.Courses;
using CAMS.domain.ValueValidationTypes;

namespace CAMS.application.Courses.GetById;

public class GetCourseByIdHandler
{
    private readonly ICourseRepository _courseRepository;

    public GetCourseByIdHandler(ICourseRepository courseRepository)
    {
        _courseRepository = courseRepository;
    }

    public async Task<Result<Course>> Handle(GetCourseByIdQuery query)
    {
        try
        {
            var course = await _courseRepository.GetCourseByIdAsync(CourseId.From(query.courseId));
            return course is not null ? Result<Course>.Success(course) : Result<Course>.Failure("Course not found");

        }
        catch (Exception ex)
        {
            return ApplicationExceptionTranslator<Course>.Translate(ex);
        }
    }

}