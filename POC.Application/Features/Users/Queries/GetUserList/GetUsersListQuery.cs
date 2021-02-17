using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace POC.Application.Features.Users.Queries.GetUserList
{
    public class GetUsersListQuery : IRequest<List<UserViewModel>>
    {
    }
}
