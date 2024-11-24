namespace CashFlow.Exception.BaseException;

public class ErrorOnValidationException(List<string> errorMessages) : CashFlowException
{
    public List<string> ErrorMessages { get; } = errorMessages;
}
