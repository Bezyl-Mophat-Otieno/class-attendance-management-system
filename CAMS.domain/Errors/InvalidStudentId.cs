namespace ClassAttendanceManagementSystem.Errors;

public class InvalidStudentId: DomainExceptions
{
    public InvalidStudentId(string errorMessage): base(errorMessage)
    {
        
    }
    
}