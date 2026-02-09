namespace ClassAttendanceManagementSystem_backend.Dtos.Student;

public record CreateStudentRequest(
    string FirstName,
    string LastName,
    string Email,
    Guid CourseId,
    int YearOfStudy
    );