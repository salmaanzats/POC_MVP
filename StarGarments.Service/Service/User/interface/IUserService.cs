using System.Collections.Generic;
using System.Threading.Tasks;

namespace StarGarments.Service.Service.User
{
    public interface IUserService
    {
        IEnumerable<POC.Domain.Entitities.User> Users { get; }
        Task<List<POC.Domain.Entitities.User>> LoadUsersAsync();
    }
}
