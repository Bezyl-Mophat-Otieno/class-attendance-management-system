using ClassAttendanceManagementSystem.Errors;

namespace CAMS.application.Common.Exceptions;

public class ApplicationExceptionTranslator<T>
{
    public static Result<T> Translate(Exception e)
    {

        return e switch
        {
            DomainException ex => Result<T>.Failure(ex.Message),
        };
    }
}