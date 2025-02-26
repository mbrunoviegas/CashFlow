﻿using CashFlow.Exception.Resources;
using System.Net;

namespace CashFlow.Exception.BaseException;

public class InvalidLoginException : CashFlowException
{
    public InvalidLoginException() : base(ErrorMessagesResources.EMAIL_OR_PASSWORD_INVALID)
    {
    }

    public override int StatusCode => (int)HttpStatusCode.Unauthorized;

    public override List<string> GetErrors()
    {
        return [Message];
    }
}

