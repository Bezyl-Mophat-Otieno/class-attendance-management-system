namespace ClassAttendanceManagementSystem_backend.Dtos.Course;

public record CreateCourseRequest(
    string CourseName,
    int CourseDuration
    );