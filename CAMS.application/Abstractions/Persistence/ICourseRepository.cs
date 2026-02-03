using CAMS.domain.Courses;
using CAMS.domain.ValueValidationTypes;

namespace CAMS.application.Abstractions.Persistence;

public interface ICourseRepository
{
    Task<Course> AddCourseAsync(Course course);
    Task<Course?> GetByNameAsync(CourseName courseName);

    Task<Course?> GetCourseByIdAsync(CourseId courseId);

}