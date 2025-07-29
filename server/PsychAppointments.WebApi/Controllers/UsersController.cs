using Microsoft.AspNetCore.Mvc;
using PsychAppointments.Application.UseCases.Users;
using PsychAppointments.Domain.Entities;

namespace PsychAppointments.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IRegisterUserUseCase _registerUserUseCase;

    public UsersController(IRegisterUserUseCase registerUserUseCase)
    {
        _registerUserUseCase = registerUserUseCase;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(User user)
    {
        try
        {
            await _registerUserUseCase.ExecuteAsync(user);
            return Ok("User registered");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
