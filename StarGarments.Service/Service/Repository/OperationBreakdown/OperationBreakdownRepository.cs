using StarGarments.Service.Service.Base;
using StarGarments.Service.Service.Repository.OperationBreakdown.Interface;
using System;
using System.Threading.Tasks;

namespace StarGarments.Service.Service.Repository.OperationBreakdown
{
    public class OperationBreakdownRepository : IOperationBreakdownRepository
    {
        private HttpServiceRepository httpServiceRepository;
        public string CreateEndPoint { get; set; } = "garmenttype";
        public string UpdateEndPoint { get; set; } = "garmenttype/";
        public string GetEndPoint { get; set; } = "ie/garment/types";
        public string DeleteEndPoint { get; set; } = "garmenttype/";

        public OperationBreakdownRepository()
        {
            httpServiceRepository = new HttpServiceRepository();
        }

        public Task Create<T>(T request)
        {
            throw new NotImplementedException();
        }

        public Task Delete(Guid request)
        {
            throw new NotImplementedException();
        }

        public async Task<T> Get<T>()
        {
            return await httpServiceRepository.Get<T>(GetEndPoint);
        }

        public Task<T> GetById<T>(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task Update<T>(Guid id, T request)
        {
            throw new NotImplementedException();
        }
    }
}
