namespace CAMS.application.Common;

public class Result<T>: Result
{
    public T Value { get; init; }

    private Result(T value): base(true, null)
    {
        Value = value;
    }

    private Result(string errorMessage) : base(false, errorMessage)
    {
    }

    public static Result<T> Success(T value) => new(value);
    public static Result<T> Failure(string errorMessage) => new(errorMessage);
    
}
