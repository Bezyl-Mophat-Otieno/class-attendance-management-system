namespace ClassAttendanceManagementSystem.Errors;

public class DomainException: Exception
{
    protected DomainException(string errorMessage): base(errorMessage)
    {
        
    }
    
}