using Newtonsoft.Json;
using StarGarments.Service.Shared.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace StarGarments.Service.Service.User
{
    public class UserService : IUserService
    {
        private List<POC.Domain.Entitities.User> users = new List<POC.Domain.Entitities.User>();
        public IEnumerable<POC.Domain.Entitities.User> Users { get { return users; } }

        public UserService()
        {
        }

        public async Task<List<POC.Domain.Entitities.User>> LoadUsersAsync()
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Get", "application/json");
                var response = await client.GetAsync("https://localhost:44342/api/users");
                var data = await response.Content.ReadAsStringAsync();
                var dd = JsonConvert.DeserializeObject<ReponseModel<List<POC.Domain.Entitities.User>>>(data);
                return users = dd.data;
            }
        }
    }
}
