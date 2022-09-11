using Application.Features.LanguageTechnologies.Commands;
using Application.Features.ProgrammingLanguages.Dtos;
using Application.Features.ProgrammingLanguages.Queries.GetByIdProgrammingLanguage;
using Application.Features.UserProfiles.Commands.CreateUserProfile;
using Application.Features.UserProfiles.Commands.DeleteUserProfile;
using Application.Features.UserProfiles.Commands.UpdateUserProfile;
using Application.Features.UserProfiles.Dtos;
using Application.Features.UserProfiles.Queries.GetByIdUserProfile;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserProfilesController : BaseController
    {
        [HttpPost("Add")]
        public async Task<IActionResult> AddAsync([FromBody] CreateUserProfileCommand createUserProfileCommand)
        {
            CreatedUserProfileDto createdUserProfileDto = await Mediator.Send(createUserProfileCommand);
            return Created("", createdUserProfileDto);
        }

        [HttpPost("Update")]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateUserProfileCommand updateUserProfileCommand)
        {
            UpdatedUserProfileDto updatedUserProfileDto = await Mediator.Send(updateUserProfileCommand);
            return Created("", updatedUserProfileDto);
        }

        [HttpDelete("delete/{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteUserProfileCommand deleteUserProfileCommand)
        {
            DeletedUserProfileDto deletedUserProfileDto = await Mediator.Send(deleteUserProfileCommand);
            return Ok(deletedUserProfileDto);
        }

        [HttpGet("getbyid/{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdUserProfileQuery getByIdUserProfileQuery)
        {
            UserProfileGetByIdDto userProfileGetByIdDto = await Mediator.Send(getByIdUserProfileQuery);
            return Ok(userProfileGetByIdDto);


        }
    }
}
