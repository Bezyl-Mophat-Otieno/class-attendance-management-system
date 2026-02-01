namespace CAMS.domain.ValueValidationTypes;

public record FullName
{
    public string FirstName { get; private set; }
    public string LastName { get; private set; }

    public string Value => $"{FirstName} {LastName}";

    private FullName(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;

    }

    public static FullName From(string firstname, string lastname) => new FullName(firstname, lastname);

};