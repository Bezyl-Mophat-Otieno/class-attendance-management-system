namespace CAMS.domain.ValueValidationTypes;

public record UnitDuration
{
    public int Value { get; }

    public UnitDuration(int duration)
    {
        if (duration is < 1 or > 60)
        {
            throw new ArgumentException("Unit duration should be greater than 0 and not exceed 60 hours");
        }

        Value = duration;
    }
}