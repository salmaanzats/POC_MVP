using AutoMapper;
using MediatR;
using Microsoft.ApplicationBlocks.Data;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace POC.Application.Features.Garment.GetGarmentTypeList
{
    public class GetGarmentTypeListQueryHandler : IRequestHandler<GetGarmentTypeListQuery, IEnumerable<GarmentTypeListViewModel>>
    {
        private readonly IMapper _mapper;
        private readonly string _conString;

        public GetGarmentTypeListQueryHandler(IMapper mapper, IConfiguration configuration)
        {
            _mapper = mapper;
            _conString = configuration.GetConnectionString("OPS-ADOConnection");
        }

        public async Task<IEnumerable<GarmentTypeListViewModel>> Handle(GetGarmentTypeListQuery request, CancellationToken cancellationToken)
        {
            using (var conn = new SqlConnection(_conString))
            {
                try
                {
                    SqlDataAdapter da = new SqlDataAdapter();
                    SqlCommand cmd = conn.CreateCommand();
                    cmd.CommandText = "Select nIEGmtTypeID,cGmtType From [OPS].[dbo].[IE_REF_GarmentType]";
                    da.SelectCommand = cmd;
                    DataSet ds = new DataSet();

                    da.Fill(ds);

                    DataTable dt = ds.Tables[0];

                    var list = _mapper.Map<IEnumerable<GarmentTypeListViewModel>>(dt.CreateDataReader());

                    return list;

                }
                catch (System.Exception ex)
                {
                    throw;
                }
            }
        }
    }
}
