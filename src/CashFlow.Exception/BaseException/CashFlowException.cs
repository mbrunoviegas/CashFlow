namespace CashFlow.Exception.BaseException;

public abstract class CashFlowException(string message) : SystemException(message)
{
    public abstract int StatusCode { get; }
    public abstract IEnumerable<string> GetErrors();
}
