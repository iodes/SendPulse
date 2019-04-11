﻿using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SendPulse.SDK.Exceptions;
using SendPulse.SDK.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace SendPulse.SDK
{
    public class SendPulseService : IDisposable
    {
        #region 속성
        public string ClientID { get; set; }

        public string ClientSecret { get; set; }

        public string AccessToken { get; private set; }

        public DateTime TokenRenewal { get; private set; }

        public DateTime TokenExpires { get; private set; }

        internal HttpClient Client { get; } = new HttpClient();
        #endregion

        #region 생성자
        public SendPulseService()
        {

        }

        public SendPulseService(string clientId, string clientSecret) : this()
        {
            ClientID = clientId;
            ClientSecret = clientSecret;
        }
        #endregion

        #region 내부 함수
        internal bool EnsureResult(JObject result)
        {
            if (result.ContainsKey("error"))
                throw new SendPulseException(result["error_description"].Value<string>());

            return true;
        }

        internal async Task<bool> RenewalTokenAsync()
        {
            var parameters = new Dictionary<string, string>
            {
                { "client_id", ClientID },
                { "client_secret", ClientSecret },
                { "grant_type", "client_credentials" }
            };

            var result = await Client.PostAsync("https://api.sendpulse.com/oauth/access_token", new FormUrlEncodedContent(parameters));
            var response = JObject.Parse(await result.Content.ReadAsStringAsync());

            if (EnsureResult(response))
            {
                TokenRenewal = DateTime.Now;
                TokenExpires = TokenRenewal.AddMinutes(response["expires_in"].Value<int>());
                AccessToken = response["access_token"].Value<string>();

                Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AccessToken);

                return true;
            }

            return false;
        }

        internal async Task<bool> EnsureTokenAsync()
        {
            if (DateTime.Now >= TokenExpires)
                return await RenewalTokenAsync();

            return true;
        }
        #endregion

        #region 사용자 함수
        public async Task<List<Template>> GetTemplatesAsync()
        {
            if (!await EnsureTokenAsync())
                throw new InvalidOperationException();

            var result = await Client.GetAsync("https://api.sendpulse.com/templates");
            return JsonConvert.DeserializeObject<List<Template>>(await result.Content.ReadAsStringAsync());
        }

        public async Task<DetailedBalance> GetBalanceAsync()
        {
            if (!await EnsureTokenAsync())
                throw new InvalidOperationException();

            var result = await Client.GetAsync("https://api.sendpulse.com/user/balance/detail");
            var response = JObject.Parse(await result.Content.ReadAsStringAsync());
            if (!EnsureResult(response))
                return null;

            return response.ToObject<DetailedBalance>();
        }
        #endregion

        #region IDisposable
        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    AccessToken = null;
                    Client?.Dispose();
                }

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }
        #endregion
    }
}
