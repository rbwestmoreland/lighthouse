using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace System.Web.Mvc
{
    public static class HtmlHelpers
    {
        public static string GetStatusLabelClass(this HtmlHelper helper, string status)
        {
            switch (status.ToLower())
            {
                case "succeeded":
                    return "label-success";
                case "queued":
                    return "label-warning";
                case "building":
                    return "label-info";
                case "failed":
                    return "label-important";
                default:
                    return string.Empty;
            }
        }
    }
}