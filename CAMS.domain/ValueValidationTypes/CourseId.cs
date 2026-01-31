namespace CAMS.domain.ValueValidationTypes;

public sealed record CourseId
{
    public Guid Value { get; }

    private CourseId(Guid value)
    {
        if (value == Guid.Empty) throw new ArgumentException("Invalid Course Id");
        Value = value;
    }


    public static CourseId New()
    {
        return new CourseId(Guid.NewGuid());
    }

    public static CourseId From(Guid value)
    {
        return new CourseId(value);
    }
}