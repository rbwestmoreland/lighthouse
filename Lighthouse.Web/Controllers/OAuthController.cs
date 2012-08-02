using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Newtonsoft.Json;

namespace Lighthouse.Web.Controllers
{
    public class OAuthController : BaseController
    {
        private string ClientId { get; set; }
        private string ClientSecretKey { get; set; }
        private string CallbackUrl { get; set; }

        public OAuthController(string clientId, string clientSecretKey, string callbackUrl)
        {
            if (string.IsNullOrWhiteSpace(clientId))
            {
                throw new ArgumentNullException("clientId");
            }

            if (string.IsNullOrWhiteSpace(clientSecretKey))
            {
                throw new ArgumentNullException("clientSecretKey");
            }

            if (string.IsNullOrWhiteSpace(callbackUrl))
            {
                throw new ArgumentNullException("callbackUrl");
            }

            ClientId = clientId;
            ClientSecretKey = clientSecretKey;
            CallbackUrl = callbackUrl;
        }

        public ActionResult Begin()
        {
            var url = string.Format("https://appharbor.com/user/authorizations/new?client_id={0}&redirect_uri={1}", ClientId, CallbackUrl);
            return Redirect(url);
        }

        public ActionResult Callback(string code)
        {
            var accessToken = string.Empty;

            if (TryGetAccessToken(code, out accessToken))
            {
                var username = GetAppHarborUsername(accessToken);
                AppendCookieToResponse(accessToken, username);
                return RedirectToRoute("Dashboard");
            }
            else
            {
                return RedirectToRoute("Home");
            }
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToRoute("Home");
        }

        private bool TryGetAccessToken(string code, out string accessToken)
        {
            var nvc = new Dictionary<string, string>();
            nvc.Add("client_id", ClientId);
            nvc.Add("client_secret", ClientSecretKey);
            nvc.Add("code", code);
            var content = new FormUrlEncodedContent(nvc);

            using (var httpClient = new HttpClient())
            {
                var response = httpClient.PostAsync("https://appharbor.com/tokens", content).Result;
                var responseBody = response.Content.ReadAsStringAsync().Result;
                var tokenData = HttpUtility.ParseQueryString(responseBody);
                accessToken = tokenData["access_token"];
            }

            return !string.IsNullOrWhiteSpace(accessToken);
        }

        private string GetAppHarborUsername(string accessToken)
        {
            var username = string.Empty;

            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("BEARER", accessToken);
                var response = httpClient.GetAsync("https://appharbor.com/user").Result;
                var responseBody = response.Content.ReadAsStringAsync().Result;
                var json = JsonConvert.DeserializeObject(responseBody) as dynamic;
                username = json.username.Value.ToString();
            }

            return username;
        }

        private void AppendCookieToResponse(string accessToken, string username)
        {
            var ticket = new FormsAuthenticationTicket(1, username, DateTime.UtcNow, DateTime.MaxValue, true, accessToken);
            var encryptedTicket = FormsAuthentication.Encrypt(ticket);
            var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
            Response.AppendCookie(cookie);
        }
    }
}
