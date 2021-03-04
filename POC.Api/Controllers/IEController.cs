using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using POC.Application.Features.Garment.GetGarmentTypeList;
using POC.Application.Features.Styles.GetStyleList;
using POC.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POC.Api.Controllers
{
    [Route("api/ie")]
    [ApiController]
    public class IEController : ControllerBase
    {
        private readonly IMediator _mediator;

        public IEController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet("garment/types", Name = "GetAllIEGarmentTypes")]
        [ProducesResponseType(typeof(SuccessResponse<IEnumerable<GarmentTypeListViewModel>>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<SuccessResponse<IEnumerable<object>>>> GetAllUsers()
        {
            var viewModel = await _mediator.Send(new GetGarmentTypeListQuery());
            return Ok(viewModel);
        }


        [HttpGet("garment/style", Name = "GetAllIEStyle")]
        [ProducesResponseType(typeof(SuccessResponse<IEnumerable<StyleListViewModel>>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<SuccessResponse<IEnumerable<StyleListViewModel>>>> GetAllStles()
        {
            var viewModel = await _mediator.Send(new GetStyleListQuery());
            return Ok(viewModel);
        }
    }
}
