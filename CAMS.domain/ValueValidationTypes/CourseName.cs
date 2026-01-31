namespace CAMS.domain.ValueValidationTypes;

public record CourseName
{
    public string Value { get;  }

    private CourseName(string value)
    {
        if (string.IsNullOrEmpty(value))
        {
            throw new ArgumentException("Invalid course name");
        }

        Value = value;
    }

    public static CourseName From(string value)
    {
        return new CourseName(value);
    }
};