namespace ClassAttendanceManagementSystem.Errors;

public class InvalidCourseName : DomainException
{
    public InvalidCourseName(string errorMessage) : base(errorMessage)
    {

    }

}