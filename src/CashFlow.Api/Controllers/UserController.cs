using AutoMapper;
using CashFlow.Application.UseCases.Users.Register;
using CashFlow.Application.Validators;
using CashFlow.Domain.Entities;
using CashFlow.DTO.Requests;
using CashFlow.External.Validators.Users;
using Microsoft.AspNetCore.Mvc;

namespace CashFlow.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController(IMapper mapper) : ControllerBase
{
    private readonly IMapper _mapper = mapper;

    [HttpPost]
    public async Task<IActionResult> Register(
        [FromServices] IRegisterUserUseCase useCase,
        [FromBody] RegisterUserRequestDTO request,
        [FromServices] IPayloadValidator<RegisterUserRequestDTO> validator
        )
    {
        validator.Validate(request);
        var response = await useCase.Execute(_mapper.Map<User>(request));

        return Created(string.Empty, response);
    }
}
