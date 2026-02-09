using CAMS.application.Abstractions.Persistence;
using CAMS.application.Common;
using CAMS.application.Common.Exceptions;
using CAMS.domain.ValueValidationTypes;
using ClassAttendanceManagementSystem.Errors;

namespace CAMS.application.Students.Create;

public class CreateStudentHandler
{
    private readonly IStudentRepository _studentRepository;
    private readonly ICourseRepository _courseRepository;

    public CreateStudentHandler(IStudentRepository studentRepository, ICourseRepository courseRepository)
    {
        _studentRepository = studentRepository;
        _courseRepository = courseRepository;
    }

    public async Task<Result<StudentId>> Handle(CreateStudentCommand command)
    {
        try
        {
            var course = await _courseRepository.GetCourseByIdAsync(CourseId.From(command.CourseId));
            var studentExists = await _studentRepository.CheckStudentExistByEmail(EmailAddress.From(command.Email));
            if (studentExists) return Result<StudentId>.Failure("Student already exists");
            if (course == null) return Result<StudentId>.Failure("Course not found");
            var student = Student.New(
                StudentName.From(command.FirstName),
                StudentName.From(command.LastName),
                EmailAddress.From(command.Email),
                course.Id,
                command.YearOfStudy
            );

            await _studentRepository.AddAsync(student);

            return Result<StudentId>.Success(student.Id);

        }
        catch (DomainException ex)
        {
            return ApplicationExceptionTranslator<StudentId>.Translate(ex);
        }
    }

}