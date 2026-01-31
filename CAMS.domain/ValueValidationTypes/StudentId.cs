namespace CAMS.domain.ValueValidationTypes;

public record StudentId(Guid id)
{
    public static StudentId New()
    {
        return new StudentId(Guid.NewGuid());
    }
}