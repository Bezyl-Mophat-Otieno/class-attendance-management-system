namespace CAMS.domain.ValueValidationTypes;

public record CourseCode
{
    public string Value { get; }

    private CourseCode(string value)
    {
        Value = value;
    }

    public static CourseCode From(CourseName name)
    {
        var code = string.Concat(name.Value.Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select((w) => char.ToUpper(w[0])));
        return new CourseCode(code);

    }
};