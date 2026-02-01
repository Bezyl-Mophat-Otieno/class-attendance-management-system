namespace CAMS.domain.ValueValidationTypes;

public sealed record LessonId
{
    public Guid Value { get; }

    private LessonId(Guid value)
    {
        if (value == Guid.Empty) throw new ArgumentException("Invalid Lesson Id");
        Value = value;
    }


    public static LessonId New()
    {
        return new LessonId(Guid.NewGuid());
    }

    public static LessonId From(Guid value)
    {
        return new LessonId(value);
    }
}