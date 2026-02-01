namespace ClassAttendanceManagementSystem.Errors;

public class InvalidCourseId: DomainExceptions
{
    public InvalidCourseId(string errorMessage): base(errorMessage)
    {
        
    }
    
}