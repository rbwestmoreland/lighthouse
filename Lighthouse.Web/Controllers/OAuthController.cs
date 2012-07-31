using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace Lighthouse.Web.Controllers
{
    public class OAuthController : Controller
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
                //todo
            }
            else
            {
                //todo
            }

            return RedirectToAction("", "");
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
    }
}
