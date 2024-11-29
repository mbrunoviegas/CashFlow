using System.Net;

namespace CashFlow.Exception.BaseException;

public class ErrorOnValidationException(List<string> errorMessages) : CashFlowException(string.Empty)
{
    private List<string> ErrorMessages { get; } = errorMessages;
    public override int StatusCode => (int)HttpStatusCode.BadRequest;

    public override IEnumerable<string> GetErrors()
    {
        return ErrorMessages;
    }
}
