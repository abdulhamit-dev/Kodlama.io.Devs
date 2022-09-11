using Application.Features.Auth.Commands.Register;
using Application.Features.Auth.Dtos;
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

        //[HttpPost]
        //public async Task<IActionResult> Login([FromBody] LoginUserQuery loginUserQuery)
        //{
        //    LoggedInUserDto result = await Mediator.Send(loginUserQuery);
        //    return Ok(result);
        //}
    }
}
