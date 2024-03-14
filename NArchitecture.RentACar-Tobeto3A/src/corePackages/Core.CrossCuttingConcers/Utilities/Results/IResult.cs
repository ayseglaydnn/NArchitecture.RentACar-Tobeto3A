namespace Core.CrossCuttingConcers.Utilities.Results;

public interface IResult
{
    bool Success { get; }
    string Message { get; }
}
