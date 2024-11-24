namespace CashFlow.Application.Validators;

public interface IPayloadValidator<T>
{
    void Validate(T entity);
}
