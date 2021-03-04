using AutoMapper;
using MediatR;
using Microsoft.Extensions.Configuration;
using POC.Application.Responses;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace POC.Application.Features.SMV.Command.GetSMVBreakDownVersion
{
    public class GetSMVBreakDownVersionQueryHandler : IRequestHandler<GetSMVBreakDownVersionQuery, SuccessResponse<SMVBreakDownVersionViewModel>>
    {
        private readonly IMapper _mapper;
        private readonly string _starIEConnString;

        public GetSMVBreakDownVersionQueryHandler(IMapper mapper, IConfiguration configuration)
        {
            _mapper = mapper;
            _starIEConnString = configuration.GetConnectionString("StarIE-ADOConnection");
        }

        public async Task<SuccessResponse<SMVBreakDownVersionViewModel>> Handle(GetSMVBreakDownVersionQuery request, CancellationToken cancellationToken)
        {
            using (var conn = new SqlConnection(_starIEConnString))
            {
                try
                {

                    SqlDataAdapter da = new SqlDataAdapter();
                    SqlCommand cmd = conn.CreateCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@In_VersionHDID", SqlDbType.Int).Value = request.VersionHDID;
                    cmd.CommandText = "Sp_IE_GetBreakDownByVertionHDID";

                    da.SelectCommand = cmd;
                    DataSet ds = new DataSet();

                    da.Fill(ds);

                    DataTable dt = ds.Tables[0];

                    var list = _mapper.Map<SMVBreakDownVersionViewModel>(dt.CreateDataReader());

                    var response = new SuccessResponse<SMVBreakDownVersionViewModel>()
                    {
                        //TotalRecordCount = list.Count(),
                        Data = list
                    };

                    return response;

                }
                catch (System.Exception ex)
                {

                    throw;
                }
            }
        }
    }
}
