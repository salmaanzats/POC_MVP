using Newtonsoft.Json;
using StarGarments.Service.Shared.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
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
                var res = JsonConvert.DeserializeObject<ReponseModel<List<POC.Domain.Entitities.User>>>(data);
                return users = res.Data;
            }
        }

        public async Task UpdateUsersAsync(POC.Domain.Entitities.User user)
        {
            using (HttpClient client = new HttpClient())
            {
                var url = $"https://localhost:44342/api/users/{user.Id}";
                client.DefaultRequestHeaders.Add("PUT", "application/json");
                var json = JsonConvert.SerializeObject(user);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var result = await client.PutAsync(url, content);
            }
        }

        public async Task SaveUserAsync(POC.Domain.Entitities.User user)
        {
            using (HttpClient client = new HttpClient())
            {
                var url = $"https://localhost:44342/api/users";
                client.DefaultRequestHeaders.Add("POST", "application/json");
                var json = JsonConvert.SerializeObject(user);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var result = await client.PostAsync(url, content);
            }
        }
    }
}
