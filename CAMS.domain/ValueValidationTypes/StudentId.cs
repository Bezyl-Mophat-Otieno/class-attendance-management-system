using ClassAttendanceManagementSystem.Errors;

namespace CAMS.domain.ValueValidationTypes;

public record StudentId
{
    public Guid Value { get; }

    private StudentId(Guid value)
    {
        if (value == Guid.Empty) throw new InvalidStudentId("StudentId should not be empty");

        Value = value;
    }

    public static StudentId New()
    {
        return new StudentId(Guid.NewGuid());
    }
    public static StudentId From(Guid value)
    {
        return new StudentId(value);
    }
}