using AutoMapper;

namespace CashFlow.Api.Mapper.Profiles;

internal class ExpensesMapperProfile: Profile
{
    public ExpensesMapperProfile()
    {
        CreateMap<DTO.Requests.ExpenseRequestDTO, Domain.Entities.Expense>();
        CreateMap<Domain.Entities.Expense, DTO.Responses.ExpenseResponseDTO>();
    }
}
