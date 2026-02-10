using CAMS.application.Abstractions.Persistence;
using CAMS.application.Common;
using CAMS.application.Common.Exceptions;
using CAMS.domain.ValueValidationTypes;

namespace CAMS.application.Courses.GetById;

public class GetStudentByIdHandler
{
    private readonly IStudentRepository _studentRepository;

    public GetStudentByIdHandler(IStudentRepository studentRepository)
    {
        _studentRepository = studentRepository;
    }

    public async Task<Result<Student>> Handle(GetStudentByIdQuery query)
    {
        try
        {
            var student = await _studentRepository.GetStudentByIdAsync(StudentId.From(query.studentId));
            return student is not null
                ? Result<Student>.Success(student)
                : Result<Student>.Failure("Student Not Found");

        }
        catch (Exception ex)
        {
            return ApplicationExceptionTranslator<Student>.Translate(ex);
        }
    }
}