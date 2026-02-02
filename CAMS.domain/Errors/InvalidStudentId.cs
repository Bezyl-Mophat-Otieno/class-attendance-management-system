namespace ClassAttendanceManagementSystem.Errors;

public class InvalidStudentId: DomainException
{
    public InvalidStudentId(string errorMessage): base(errorMessage)
    {
        
    }
    
}