namespace CAMS.domain.ValueValidationTypes;

public record CourseDuration
{
    public int Value { get; }

    private CourseDuration(int duration)
    {
        if (duration is < 1 or > 6)
        {
            throw new ArgumentException("Course duration should be greater than 0 and not exceed 6 years");
        }

        Value = duration;
    }

    public static CourseDuration From(int value)
    {
        return new CourseDuration(value);
    }
}