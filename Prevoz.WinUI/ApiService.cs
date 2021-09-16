using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flurl.Http;
using Flurl;
using Prevoz.Model;

namespace Prevoz.WinUI
{
    public class ApiService
    {
        public static string Username { get; set; }
        public static string Password { get; set; }

        private readonly string _route = null;
        public ApiService(string route)
        {
            _route = route;
        }
        public async Task<T> Get<T>(object search)
        {
            var url = $"{Properties.Settings.Default.APIURL}/{_route}";

            if(search != null)
            {
                url += "?";
                url +=await search.ToQueryString();
            }

            var result = await url.WithBasicAuth(Username, Password).GetJsonAsync<T>();

            return result;
        }
        public async Task<T> GetById<T>(object Id)
        {
            var url = $"{Properties.Settings.Default.APIURL}/{_route}/{Id}";
            var result = await url.WithBasicAuth(Username, Password).GetJsonAsync<T>();
            return result;
        }

        public async Task<T> Insert<T>(object request)
        {
            var url = $"{Properties.Settings.Default.APIURL}/{_route}";
            return await url.WithBasicAuth(Username, Password).PostJsonAsync(request).ReceiveJson<T>();
        }

        public async Task<T> Update<T>(object Id, object request)
        {
            var url = $"{Properties.Settings.Default.APIURL}/{_route}/{Id}";
            return await url.WithBasicAuth(Username, Password).PutJsonAsync(request).ReceiveJson<T>();
        }

        public async Task<T> Delete<T>(object Id)
        {
            var url = $"{Properties.Settings.Default.APIURL}/{_route}/{Id}";
            return await url.WithBasicAuth(Username, Password).DeleteAsync().ReceiveJson<T>();
        }     
    }
}
