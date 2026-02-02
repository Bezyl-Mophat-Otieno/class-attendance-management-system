using CAMS.application.Abstractions.Persistence;
using CAMS.application.Common;
using CAMS.domain.Courses;
using CAMS.domain.ValueValidationTypes;
using ClassAttendanceManagementSystem.Errors;

namespace CAMS.application.Courses.Create;

public class CreateCourseHandler
{
    private readonly ICourseRepository _courseRepository;

    public CreateCourseHandler(ICourseRepository courseRepository)
    {
        _courseRepository = courseRepository;
    }

    public async Task<Result<CourseId>> Handle(CreateCourseCommand command)
    {
        try
        {
            var courseName = CourseName.From(command.CourseName);
            var courseDuration = CourseDuration.From(command.CourseDuration);
            var existingCourse = await _courseRepository.GetByNameAsync(courseName);
            if(existingCourse != null) return Result<CourseId>.Failure("Course with the course name already exists.");
            var course = Course.Create(
                courseName,
                courseDuration
                );
            await _courseRepository.AddCourseAsync(course);
            return Result<CourseId>.Success(course.Id);
        }
        catch (DomainException e)
        {
            return Result<CourseId>.Failure(e.Message);
        }
    }
}