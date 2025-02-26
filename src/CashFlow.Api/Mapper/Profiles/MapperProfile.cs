using AutoMapper;

namespace CashFlow.Api.Mapper.Profiles;

internal class MapperProfile: Profile
{
    public MapperProfile()
    {
        ExpenseMapping();
        UserMapping();
        UserMapping();
    }

    private void ExpenseMapping()
    {
        CreateMap<DTO.Requests.ExpenseRequestDTO, Domain.Entities.Expense>();
        CreateMap<Domain.Entities.Expense, DTO.Responses.ExpenseResponseDTO>();
    }

    private void UserMapping()
    {
        CreateMap<DTO.Requests.RegisterUserRequestDTO, Domain.Entities.User>();
        CreateMap<Domain.Entities.User, DTO.Responses.RegisterExpenseResponseDTO>();
    }
}
