namespace ClassAttendanceManagementSystem.Errors;

public class InvalidEmailAddress: DomainExceptions
{
    public InvalidEmailAddress(string errorMessage): base(errorMessage) { }
    
}