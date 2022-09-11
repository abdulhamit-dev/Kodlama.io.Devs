using Application.Features.Auth.Commands.Register;
using Application.Features.Auth.Dtos;
using Application.Features.Auth.Queries.Login;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : BaseController
    {
        [HttpPost("Register")]
        public async Task<ActionResult> Register([FromBody] RegisterUserCommand registerUserCommand)
        {
            UserRegisterDto result = await Mediator.Send(registerUserCommand);
            return Created("", result);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginUserQuery loginUserQuery)
        {
            UserLoginDto result = await Mediator.Send(loginUserQuery);
            return Ok(result);
        }
    }
}
