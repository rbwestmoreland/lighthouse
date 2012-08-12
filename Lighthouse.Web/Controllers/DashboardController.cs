using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Mvc;
using Lighthouse.Web.Models.Dashboard;
using Newtonsoft.Json;

namespace Lighthouse.Web.Controllers
{
    [Authorize]
    public class DashboardController : BaseController
    {
        public ActionResult Default()
        {
            return View();
        }

        public ActionResult Content()
        {
            var accessToken = GetUserAppHarborAccessToken();

            var model = new Dashboard();
            model.Applications = GetApplications(accessToken);

            return View(model);
        }

        private IEnumerable<Application> GetApplications(string accessToken)
        {
            var applications = new List<Application>();

            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("BEARER", accessToken);
                var response = httpClient.GetAsync("https://appharbor.com/applications").Result;
                var responseBody = response.Content.ReadAsStringAsync().Result;
                var json = JsonConvert.DeserializeObject(responseBody) as dynamic;
                var applicationArray = json as IEnumerable<dynamic>;

                foreach (var application in applicationArray)
                {
                    applications.Add(new Application()
                    {
                        Name = application.name.Value.ToString(),
                        Slug = application.slug.Value.ToString(),
                        Url = application.url.Value.ToString(),
                        Builds = GetApplicationBuilds(accessToken, application.slug.Value.ToString())
                    });
                }
            }

            return applications;
        }

        private IEnumerable<Build> GetApplicationBuilds(string accessToken, string slug)
        {
            var builds = new List<Build>();

            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("BEARER", accessToken);
                var response = httpClient.GetAsync(string.Format("https://appharbor.com/applications/{0}/builds", slug)).Result;
                var responseBody = response.Content.ReadAsStringAsync().Result;
                var json = JsonConvert.DeserializeObject(responseBody) as dynamic;
                var buildArray = json as IEnumerable<dynamic>;

                foreach (var buildItem in buildArray)
                {
                    var build = new Build();
                    build.Status = buildItem.status.Value;
                    build.Created = buildItem.created.Value;
                    build.Deployed = buildItem.deployed.Value;
                    build.CommitId = buildItem.commit.id.Value;
                    build.CommitMessage = buildItem.commit.message.Value;
                    build.DownloadUrl = buildItem.download_url.Value;
                    build.TestsUrl = buildItem.tests_url.Value;
                    build.Url = buildItem.url.Value;
                    builds.Add(build);
                }
            }

            return builds;
        }
    }
}
