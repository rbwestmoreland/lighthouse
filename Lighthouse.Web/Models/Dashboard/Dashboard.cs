using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lighthouse.Web.Models.Dashboard
{
    public class Dashboard
    {
        public IEnumerable<Application> Applications { get; set; }

        public Dashboard()
        {
            Applications = new List<Application>();
        }
    }
}