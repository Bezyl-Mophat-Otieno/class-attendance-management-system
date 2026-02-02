
using CAMS.domain.ValueValidationTypes;

namespace CAMS.domain.Courses;

public class Course
{
    public CourseId Id { get; private set; }
    public CourseName CourseName { get; private set; }
    public CourseCode CourseCode { get; private set; }
    public CourseDuration CourseDuration { get; private set; }

    private Course(CourseId id,  CourseName name, CourseDuration duration)
    {
        Id = id;
        CourseName = name;
        CourseCode = CourseCode.From(name);
        CourseDuration = duration;
    }

    public static Course Create(CourseName name, CourseDuration duration)
    {
        return new Course(CourseId.New(), name, duration);
    }
    
    public void Rename(CourseName name)
    {
        CourseName = name;
        CourseCode = CourseCode.From(name);
    }
}