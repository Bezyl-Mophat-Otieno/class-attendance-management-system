namespace CAMS.application.Students.Create;

public record CreateStudentCommand(
    string FirstName,
    string LastName,
    string Email,
    Guid CourseId,
    int YearOfStudy
    );