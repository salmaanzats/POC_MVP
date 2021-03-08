using AutoMapper;
using MediatR;
using Microsoft.Extensions.Configuration;
using POC.Application.Responses;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
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
                    cmd.Parameters.Add("@In_VersionHDID", SqlDbType.Int).Value = 274647;// request.VersionHDID;
                    cmd.CommandText = "Sp_IE_GetBreakDownByVertionHDID";

                    da.SelectCommand = cmd;
                    DataSet ds = new DataSet();

                    da.Fill(ds);

                    DataTable dtHeader = ds.Tables[0];
                    DataTable dtDetails = ds.Tables[1];
                    DataTable dtReviewData = ds.Tables[2];

                    var smvBDHeader = (_mapper.Map<IEnumerable<SMVBreakDownVersionViewModel>>(dtHeader.CreateDataReader())).FirstOrDefault();

                    var smvDetails = _mapper.Map<IEnumerable<SMVBreakDownDetails>>(dtDetails.CreateDataReader());

                    var smvReviewData = _mapper.Map<IEnumerable<IEData>>(dtReviewData.CreateDataReader());

                    if(smvDetails.Any())
                    {
                        foreach (var svmDetail in smvDetails)
                        {
                            svmDetail.NewMcCode = new IEData
                            {
                                MCCodeID = dtReviewData.AsEnumerable().Where(r => r.Field<int?>("nOperationID") == svmDetail.OperationMaster.OperationID) == null ? svmDetail.McCode.MCCodeID : dtReviewData.AsEnumerable().Where(r => r.Field<int?>("nOperationID") == svmDetail.OperationMaster.OperationID)?.FirstOrDefault() == null ? svmDetail.McCode.MCCodeID == null ? default(int) : svmDetail.McCode.MCCodeID : dtReviewData.AsEnumerable().Where(r => r.Field<int?>("nOperationID") == svmDetail.OperationMaster.OperationID).FirstOrDefault().Field<int>("nMcCodeID"),

                                MCCode = dtReviewData.AsEnumerable().Where(r => r.Field<int?>("nOperationID") == svmDetail.OperationMaster.OperationID) == null ? svmDetail.McCode.MCCode == null ? "" : svmDetail.McCode.MCCode.Trim() : dtReviewData.AsEnumerable().Where(r => r.Field<int?>("nOperationID") == svmDetail.OperationMaster.OperationID)?.FirstOrDefault() == null ? svmDetail.McCode.MCCode == null ? "" : svmDetail.McCode.MCCode.Trim() : dtReviewData.AsEnumerable().Where(r => r.Field<int?>("nOperationID") == svmDetail.OperationMaster.OperationID).FirstOrDefault().Field<string>("McCode")
                            };
                        }
                    }
                    smvBDHeader.SMVBreakDownDetail = smvDetails;

                    var response = new SuccessResponse<SMVBreakDownVersionViewModel>()
                    {
                        Data = smvBDHeader
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
