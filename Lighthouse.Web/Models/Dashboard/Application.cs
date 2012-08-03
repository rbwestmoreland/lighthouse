using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lighthouse.Web.Models.Dashboard
{
    public class Application
    {
        public string Name { get; set; }
        public string Slug { get; set; }
        public string Url { get; set; }
        public IEnumerable<Build> Builds { get; set; }
    }
}