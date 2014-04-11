using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Cirrious.CrossCore;
using Cirrious.CrossCore.Platform;
using HaveIBeenPwned.Mobile.Core.Models;

namespace HaveIBeenPwned.Mobile.Core.Services
{
    public interface IApiService
    {
        Task<List<Breach>> GetAllBreachesForAccount(string account);
    }

    public class ApiService : IApiService
    {
        private readonly HttpClient _httpClient;
        private readonly IMvxJsonConverter _jsonConverter;

        public ApiService(HttpClient httpClient, IMvxJsonConverter jsonConverter)
        {
            _httpClient = httpClient;
            _jsonConverter = jsonConverter;
            _httpClient.BaseAddress = new Uri("https://haveibeenpwned.com/api/");
            _httpClient.DefaultRequestHeaders.UserAgent.ParseAdd("HaveIBeenPwned Mobile chrisondotnet.com/0.1");
            _httpClient.DefaultRequestHeaders.Add("api-version", "2");
        }   

        public async Task<List<Breach>> GetAllBreachesForAccount(string account)
        {
            if(string.IsNullOrWhiteSpace(account))
                throw new ArgumentNullException("account");
            
            var result = await _httpClient.GetAsync(string.Format("breachedaccount/{0}", Uri.EscapeUriString(account)));

            return result.IsSuccessStatusCode ? _jsonConverter.DeserializeObject<List<Breach>>(await result.Content.ReadAsStringAsync()) : new List<Breach>();
        }
    }
}
