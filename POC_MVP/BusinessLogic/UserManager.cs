using POC_MVP.Model;
using System.Collections.Generic;
using System.Net.Http;

namespace POC_MVP.BusinessLogic
{
    public class UserManager : IUserManager
    {
        private List<UserModel> users = new List<UserModel>();
        public IEnumerable<UserModel> Users { get { return users; } }
        public UserManager()
        {
            LoadUsers();
        }

        private async void LoadUsers()
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Get", "application/json");
                var response = await client.GetAsync("http://localhost:64014/user");
                users = await response.Content.ReadAsAsync<List<UserModel>>();
                //users = JsonConvert.DeserializeObject<List<UserModel>>(context);
            }

            //var client = new WebClient();

            //var content = client.DownloadString($"http://localhost:64014/user");

            ////// Simulate that the web call takes a very long time
            ////Thread.Sleep(10000);

            //users = JsonConvert.DeserializeObject<List<UserModel>>(content);
        }
    }
}
