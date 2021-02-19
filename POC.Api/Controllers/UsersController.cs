using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using POC.Application.Features.Users.Command.CreateUser;
using POC.Application.Features.Users.Command.UpdateUser;
using POC.Application.Features.Users.Queries.GetUserDetail;
using POC.Application.Features.Users.Queries.GetUserList;
using POC.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POC.Api.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet(Name = "GetAllUsers")]
        [ProducesResponseType(typeof(Response<IEnumerable<UserViewModel>>), StatusCodes.Status200OK)]
        public async Task<ActionResult<Response<IEnumerable<UserViewModel>>>> GetAllUsers()
        {
            var viewModel = await _mediator.Send(new GetUsersListQuery());
            return Ok(viewModel);
        }


        [HttpGet("{id}", Name = "GetUser")]
        [ProducesResponseType(typeof(Response<UserDetailViewModel>), StatusCodes.Status200OK)]
        public async Task<ActionResult<Response<UserDetailViewModel>>> GetUser(Guid id)
        {
            var viewModel = await _mediator.Send(new GetUserDetailQuery() { UserId = id });
            return Ok(viewModel);
        }

        [HttpPost(Name = "AddUser")]
        public async Task<ActionResult<Response<CreateUserCommandResponse>>> Create([FromBody] CreateUserCommand createUserCommand)
        {
            var response = await _mediator.Send(createUserCommand);

            if (response.Success)
                return CreatedAtRoute(nameof(GetUser), new { id = response.Data.Id }, response);

            else
                return BadRequest(response);
        }

        [HttpPut("{id}", Name = "UpdateUser")]
        public async Task<ActionResult<Response<CreateUserCommandResponse>>> UpdateUser(Guid id, [FromBody] UpdateUserCommand updateUserCommand)
        {
            updateUserCommand.Id = id;
            await _mediator.Send(updateUserCommand);

            return NoContent();
        }
    }
}
