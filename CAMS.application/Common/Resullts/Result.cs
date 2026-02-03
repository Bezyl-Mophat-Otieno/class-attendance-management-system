namespace CAMS.application.Common;

public class Result
{
    public bool IsSuccess { get; private set; }
    public bool IsFailure => !IsSuccess;
    public string ErrorMessage { get; private set; }

    protected Result(bool isSuccess, string errorMessage)
    {
        if (isSuccess && !string.IsNullOrEmpty(errorMessage))
        {
            throw new InvalidOperationException();
        }
        if (!isSuccess && string.IsNullOrEmpty(errorMessage))
        {
            throw new InvalidOperationException();
        }

        IsSuccess = isSuccess;
        ErrorMessage = errorMessage;

    }

    public static Result Success()
    {
        return new Result(true, null);
    }
    public static Result Failure(string errorMessage)
    {
        return new Result(false, errorMessage);
    }

}