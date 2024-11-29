using System.Net;

namespace CashFlow.Exception.BaseException;
public class NotFoundException(string message) : CashFlowException(message)
{
    public override int StatusCode => (int)HttpStatusCode.NotFound;

    public override IEnumerable<string> GetErrors()
    {
        return [Message];
    }
}
