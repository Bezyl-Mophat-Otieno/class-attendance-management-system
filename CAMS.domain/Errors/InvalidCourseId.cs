namespace ClassAttendanceManagementSystem.Errors;

public class InvalidCourseId : DomainException
{
    public InvalidCourseId(string errorMessage) : base(errorMessage)
    {

    }

}