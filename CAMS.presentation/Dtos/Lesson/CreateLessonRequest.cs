namespace ClassAttendanceManagementSystem_backend.Dtos.Course;

public record CreateLessonRequest(
    Guid UnitID,
    DateTime StarDateTime,
    DateTime EndDateTime
    );