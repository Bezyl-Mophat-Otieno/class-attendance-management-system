namespace CAMS.application.Courses.Create;

public record CreateCourseCommand(
    string CourseName,
    int CourseDuration
    );