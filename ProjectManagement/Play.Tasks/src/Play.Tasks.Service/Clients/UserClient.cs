using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Play.Tasks.Service.Clients
{
    public class UserClient
    {
        private readonly HttpClient httpClient;
        public UserClient(HttpClient httpClient)
        {

            this.httpClient = httpClient;
        }
        public async Task<IReadOnlyCollection<UserInfoDto>> GetUserInfosAsync()
        {
            var userInfos = await httpClient.GetFromJsonAsync<IReadOnlyCollection<UserInfoDto>>("/users");
            return userInfos;
        }
    }
}