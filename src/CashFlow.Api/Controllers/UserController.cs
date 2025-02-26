using AutoMapper;
using CashFlow.Application.UseCases.Users.Register;
using CashFlow.Domain.Entities;
using CashFlow.DTO.Requests;
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
        [FromBody] RegisterUserRequestDTO request)
    {
        var response = await useCase.Execute(_mapper.Map<User>(request));

        return Created(string.Empty, response);
    }
}
