using Stargarments.Domain.Entities.OperationBreakDown;
using StarGarments.Service.Service.Repository.OperationBreakdown;
using StarGarments.Service.Service.Repository.OperationBreakdown.Interface;
using StarGarments.Service.Shared.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StarGarments.Service.Service.OperationBreakdown
{
    public class OperationBreakDownService : IOperationBreakdownService
    {
        private IOperationBreakdownRepository operationBreakdownRepository;

        public OperationBreakDownService()
        {
            operationBreakdownRepository = new OperationBreakdownRepository();
        }

        public async Task<List<GarmentTypeModel>> LoadGarmentTypesAsync()
        {
            var res = await operationBreakdownRepository.Get<ReponseModel<List<GarmentTypeModel>>>();
            return res.Data;
        }
    }
}
