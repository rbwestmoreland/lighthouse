using System.Linq;
using System.Web.Mvc;

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
    }
}
