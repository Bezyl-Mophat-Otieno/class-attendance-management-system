namespace ClassAttendanceManagementSystem_backend.Dtos.Course;

public record CreateUnitRequest(
    string unitName,
    int unitDuration,
    Guid courseId
    );