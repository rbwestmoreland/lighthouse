using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace System.Web.Mvc
{
    public static class HtmlHelpers
    {
        public static string GetButtonClass(this HtmlHelper helper, string status)
        {
            switch (status.ToLower())
            {
                case "succeeded":
                    return "btn-success";
                case "queued":
                    return "btn-warning";
                case "building":
                    return "btn-info";
                case "failed":
                    return "btn-danger";
                default:
                    return string.Empty;
            }
        }

        public static string GetIconClass(this HtmlHelper helper, string status)
        {
            switch (status.ToLower())
            {
                case "succeeded":
                    return "icon-ok-sign";
                case "queued":
                    return "icon-info-sign";
                case "building":
                    return "icon-question-sign";
                case "failed":
                    return "icon-remove-sign";
                default:
                    return "icon-question-sign";
            }
        }
    }
}