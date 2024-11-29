namespace CashFlow.DTO.Responses;

public class ErrorResponse
{
    public IEnumerable<string> Errors { get; set; } = [];

    public ErrorResponse(IEnumerable<string> errorMessages)
    {
        Errors = errorMessages;
    }

    public ErrorResponse(string errorMessage)
    {
        Errors = [errorMessage];
    }
}
