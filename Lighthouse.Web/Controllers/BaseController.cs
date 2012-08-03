using System.Linq;
using System.Web.Mvc;
using System.Web.Security;

namespace Lighthouse.Web.Controllers
{
    public class BaseController : Controller
    {
        protected override void HandleUnknownAction(string actionName)
        {
            Response.Redirect("~/");
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (Request.QueryString.AllKeys.Contains("ReturnUrl"))
            {
                Response.Redirect(Request.Path);
            }
        }

        protected string GetUserAppHarborAccessToken()
        {
            var accessToken = string.Empty;

            try
            {
                var httpCookie = Request.Cookies[FormsAuthentication.FormsCookieName];
                var decryptedCookie = FormsAuthentication.Decrypt(httpCookie.Value);
                accessToken = decryptedCookie.UserData;
            }
            catch { }

            return accessToken;
        }
    }
}
