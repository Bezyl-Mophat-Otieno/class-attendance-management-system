namespace ClassAttendanceManagementSystem.Errors;

public class InvalidEmailAddress : DomainException
{
    public InvalidEmailAddress(string errorMessage) : base(errorMessage) { }

}