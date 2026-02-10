using ClassAttendanceManagementSystem.Errors;

namespace CAMS.domain.ValueValidationTypes;

public sealed record EmailAddress
{
    public string Value { get; private set; }

    public EmailAddress(string value)
    {
        if (string.IsNullOrWhiteSpace(value)) throw new InvalidEmailAddress("Email cannot be empty");

        if (!value.Contains('@')) throw new InvalidEmailAddress("A valid email address must have the @ symbol");

        Value = value;
    }

    public static EmailAddress From(string email) => new(email);

}