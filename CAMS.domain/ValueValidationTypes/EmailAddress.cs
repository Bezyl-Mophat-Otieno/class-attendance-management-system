namespace CAMS.domain.ValueValidationTypes;

public sealed record EmailAddress
{
    public EmailAddress(string value)
    {
        if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException("Email cannot be empty");

        if (value.Contains('@')) throw new ArgumentException("Invalid email address");

        Value = value;
    }

    public string Value { get; }
}