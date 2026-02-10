using ClassAttendanceManagementSystem.Errors;

namespace CAMS.domain.ValueValidationTypes;

public record StudentName
{

    public string Value { get; private set; }

    private StudentName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("Invalid Student Name provided");
        }
        Value = name;
    }

    public static StudentName From(string value) => new(value);

};