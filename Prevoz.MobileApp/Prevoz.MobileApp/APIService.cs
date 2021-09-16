﻿using Flurl.Http;
using Flurl;
using Prevoz.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace Prevoz.MobileApp
{
    public class ApiService
    {
        public static string Username { get; set; }
        public static string Password { get; set; }

        private readonly string _route = null;

#if DEBUG
        private string _apiUrl = "http://localhost:51687/api"; 
#endif

#if RELEASE
        private string _apiUrl = "https://Prevoz.com/api/";
#endif
        public ApiService(string route)
        {
            _route = route; 
        }
        public async Task<T> Get<T>(object search)
        {
            var url = $"{_apiUrl}/{_route}";
            try
            {

                if (search != null)
                {
                    url += "?";
                    url += await search.ToQueryString();
                }
                var res = await url.WithBasicAuth(Username, Password).GetJsonAsync<T>();

                return res;
            }
            catch (FlurlHttpException ex)
            {
                if (ex.StatusCode == (int)System.Net.HttpStatusCode.Unauthorized)
                {
                    await Application.Current.MainPage.DisplayAlert("Greška", "Niste autentificirani", "OK");
                }
                throw;
            }
        }
        public async Task<T> GetById<T>(object Id)
        {
            var url = $"{_apiUrl}/{_route}/{Id}";
            var result = await url.WithBasicAuth(Username, Password).GetJsonAsync<T>();
            return result;
        }
        public async Task<T> GetAction<T>(string action, object search = null)
        {
            var url = $"{_apiUrl}/{_route}/{action}";

            if (search != null)
            {
                url += "?";
                url += await search.ToQueryString();
            }

            return await url.WithBasicAuth(Username, Password).GetJsonAsync<T>();
        }
        public async Task<T> Insert<T>(object request)
        {
            var url = $"{_apiUrl}/{_route}";
            try
            {
                return await url.WithBasicAuth(Username, Password).PostJsonAsync(request).ReceiveJson<T>();
            }
            catch(FlurlHttpException ex)
            {
                var errors = await ex.GetResponseJsonAsync<Dictionary<string, string[]>>();

                var stringBuilder = new StringBuilder();
                foreach (var error in errors)
                {
                    stringBuilder.AppendLine($"{error.Key}, ${string.Join(",", error.Value)}");
                }
                await Application.Current.MainPage.DisplayAlert("Greška", "Niste autentificirani", "OK");

                return default(T);
            }
        }

        public async Task<T> Update<T>(object Id, object request)
        {
            try
            {
                var url = $"{_apiUrl}/{_route}/{Id}";
                return await url.WithBasicAuth(Username, Password).PutJsonAsync(request).ReceiveJson<T>();
            }
            catch (FlurlHttpException ex)
            {
                var errors = await ex.GetResponseJsonAsync<Dictionary<string, string[]>>();

                var stringBuilder = new StringBuilder();

                foreach (var error in errors)
                {
                    stringBuilder.AppendLine($"{error.Key}, ${string.Join(",", error.Value)}");
                }
                await Application.Current.MainPage.DisplayAlert("Greška", "Niste autentificirani", "OK");

                return default(T);
            }
        }

        public async Task<T> Delete<T>(object Id)
        {
            var url = $"{_apiUrl}/{_route}/{Id}";
            return await url.WithBasicAuth(Username, Password).DeleteAsync().ReceiveJson<T>();
        }
    }
}