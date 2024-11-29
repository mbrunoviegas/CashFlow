using AutoMapper;

namespace CashFlow.Api.Mapper.Profiles;

internal class ExpensesMapperProfile: Profile
{
    public ExpensesMapperProfile()
    {
        CreateMap<DTO.Requests.RegisterExpenseRequestDTO, Domain.Entities.Expense>();
        CreateMap<Domain.Entities.Expense, DTO.Responses.ExpenseResponseDTO>();
    }
}
