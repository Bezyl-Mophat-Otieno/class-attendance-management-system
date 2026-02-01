namespace ClassAttendanceManagementSystem.Errors;

public class DomainExceptions: Exception
{
    protected DomainExceptions(string errorMessage): base(errorMessage)
    {
        
    }
    
}