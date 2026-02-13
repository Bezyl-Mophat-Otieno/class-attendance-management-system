namespace CAMS.domain.ValueValidationTypes;

public record LessonDuration
{
    public TimeSpan Value { get; }

    private LessonDuration(TimeSpan duration)
    {
        if (duration.TotalHours is > 3 or < 1)
        {
            throw new ArgumentException("A lesson can only be a minimum of 1 hour and a maximum of 3 hours");
        }

        Value = duration;
    }

    public static LessonDuration From(DateTime start, DateTime end)
    {
        if (end <= start) throw new ArgumentException("Lesson end must be after start.");
        return new LessonDuration(end.Subtract(start));
    }

    public static LessonDuration FromTimespan(TimeSpan timespan)
    {
        return new LessonDuration(timespan);
    }



};