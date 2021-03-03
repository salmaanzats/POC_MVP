using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace POC.Application.Features.Garment.GetGarmentTypeList
{
    public class GetGarmentTypeListQuery : IRequest<IEnumerable<GarmentTypeListViewModel>>
    {
    }
}
