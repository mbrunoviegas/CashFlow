using CashFlow.Application.UseCases.Login;
using CashFlow.DTO.Requests;
using Microsoft.AspNetCore.Mvc;

namespace CashFlow.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Login(
            [FromBody] LoginRequestDTO request,
            [FromServices] ILoginUseCase loginUseCase)
        {
            var user = await loginUseCase.Execute(request);
            return Ok(user);
        }
    }
}
