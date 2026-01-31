namespace CAMS.domain.ValueValidationTypes;

public record UnitCode
{
    public string Value { get; }

    private UnitCode(string value)
    {
        Value = value;
    }

    public static UnitCode From(UnitName name)
    {
        var code = string.Concat(name.Value.Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select((w)=> char.ToUpper(w[0])));
        return new UnitCode(code);

    }
};