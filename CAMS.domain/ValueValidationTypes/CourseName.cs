using ClassAttendanceManagementSystem.Errors;

namespace CAMS.domain.ValueValidationTypes;

public record CourseName
{
    public string Value { get; }

    private CourseName(string value)
    {
        if (string.IsNullOrEmpty(value))
        {
            throw new InvalidCourseName("Course name can not be empty");
        }

        Value = value;
    }

    public static CourseName From(string value)
    {
        return new CourseName(value);
    }
};