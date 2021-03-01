using StarGarments.Service.Service.Base;
using StarGarments.Service.Shared.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StarGarments.Service.Service.User
{
    public class UserService : IUserService
    {
        private List<POC.Domain.Entitities.User> users = new List<POC.Domain.Entitities.User>();
        public IEnumerable<POC.Domain.Entitities.User> Users { get { return users; } }
        private UserServiceRepository userServiceRepository;

        public UserService()
        {
            userServiceRepository = new UserServiceRepository();
        }

        public async Task<List<POC.Domain.Entitities.User>> LoadUsersAsync()
        {
            var res = await userServiceRepository.Get<ReponseModel<List<POC.Domain.Entitities.User>>>();
            return users = res.Data;
        }

        public async Task UpdateUsersAsync(POC.Domain.Entitities.User user)
        {
            await userServiceRepository.Update<POC.Domain.Entitities.User>(user.Id,user);
        }

        public async Task SaveUserAsync(POC.Domain.Entitities.User user)
        {
            await userServiceRepository.Create<POC.Domain.Entitities.User>(user);
        }

        public async Task DeleteUserAsync(Guid id)
        {
            await userServiceRepository.Delete(id);
        }
    }
}
