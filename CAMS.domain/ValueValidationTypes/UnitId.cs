namespace CAMS.domain.ValueValidationTypes;

public sealed record UnitId
{
    public Guid Value { get; }

    private UnitId(Guid value)
    {
        if (value == Guid.Empty) throw new ArgumentException("Invalid Course Id");
        Value = value;
    }


    public static UnitId New()
    {
        return new UnitId(Guid.NewGuid());
    }

    public static UnitId From(Guid value)
    {
        return new UnitId(value);
    }
}