using Application.Features.LanguageTechnologies.Commands;
using Application.Features.LanguageTechnologies.Dtos;
using Application.Features.LanguageTechnologies.Models;
using Application.Features.LanguageTechnologies.Queries.GetListLanguageTechnology;
using Core.Application.Requests;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LanguageTechnologiesController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateLanguageTechnologyCommand createLanguageTechnologyCommand)
        {
            CreatedLanguageTechnologyDto result = await Mediator.Send(createLanguageTechnologyCommand);
            return Created("", result);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteLanguageTechnologyCommand deleteLanguageTechnologyCommand)
        {
            var result = await Mediator.Send(deleteLanguageTechnologyCommand);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateLanguageTechnologyCommand updateLAnguageTechnologyCommand)
        {
            var result = await Mediator.Send(updateLAnguageTechnologyCommand);
            return Ok(result);
        }

        [HttpGet("getlist")]
        public async Task<ActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListLanguageTechnologyQuery getListLanguageTechnologyQuery = new GetListLanguageTechnologyQuery { PageRequest = pageRequest };
            LanguageTechnologyListModel result = await Mediator.Send(getListLanguageTechnologyQuery);
            return Ok(result);
        }
    }
}
