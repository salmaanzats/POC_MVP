using AutoMapper;
using MediatR;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace POC.Application.Features.Styles.GetStyleList
{
    public class GetStyleListQueryHandler : IRequestHandler<GetStyleListQuery, IEnumerable<StyleListViewModel>>
    {
        private readonly IMapper _mapper;
        private readonly string _conString;

        public GetStyleListQueryHandler(IMapper mapper, IConfiguration configuration)
        {
            _mapper = mapper;
            _conString = configuration.GetConnectionString("OPS-ADOConnection");
        }

        public async Task<IEnumerable<StyleListViewModel>> Handle(GetStyleListQuery request, CancellationToken cancellationToken)
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

                    var list = dt.AsEnumerable().Select(g => new StyleListViewModel
                    {
                        StyleNumber = g.Field<string>("Style"),

                    }).ToList();


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
