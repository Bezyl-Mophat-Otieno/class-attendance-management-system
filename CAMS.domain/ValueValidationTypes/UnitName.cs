namespace CAMS.domain.ValueValidationTypes;

public record UnitName
{
    public string Value { get;  }

    private UnitName(string value)
    {
        if (string.IsNullOrEmpty(value))
        {
            throw new ArgumentException("Invalid Unit name");
        }

        Value = value;
    }

    public static UnitName From(string value)
    {
        return new UnitName(value);
    }
};