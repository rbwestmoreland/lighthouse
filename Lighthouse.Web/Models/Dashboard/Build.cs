using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lighthouse.Web.Models.Dashboard
{
    public class Build
    {
        public string Status { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Deployed { get; set; }
        public string CommitId { get; set; }
        public string CommitMessage { get; set; }
        public string DownloadUrl { get; set; }
        public string TestsUrl { get; set; }
        public string Url { get; set; }
    }
}