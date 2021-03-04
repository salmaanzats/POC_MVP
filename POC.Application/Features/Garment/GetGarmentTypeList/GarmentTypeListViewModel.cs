using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace POC.Application.Features.Garment.GetGarmentTypeList
{
    public class GarmentTypeListViewModel
    {
        public int GarmentTypeId { get; set; }
        public string GarmentType { get; set; }
    }
}
