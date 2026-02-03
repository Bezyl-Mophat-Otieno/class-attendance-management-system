using CAMS.domain.ValueValidationTypes;

namespace CAMS.application.Abstractions.Persistence;

public interface IStudentRepository
{
    Task AddAsync(Student student);
    Task<Student?> GetStudentByIdAsync(StudentId studentId);
    Task<bool> CheckStudentExistByEmail(EmailAddress studentEmail);
}