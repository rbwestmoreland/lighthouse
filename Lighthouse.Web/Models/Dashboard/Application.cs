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

        public Application()
        {
            Builds = new List<Build>();
        }

        public IEnumerable<Build> GetQueuedBuilds()
        {
            if (Builds.IsNotNullAndNotEmpty())
            {
                return Builds.Where(b => b.Status.Equals("queued", StringComparison.OrdinalIgnoreCase));
            }
            else
            {
                return new List<Build>();
            }
        }

        public IEnumerable<Build> GetBuildingBuilds()
        {
            if (Builds.IsNotNullAndNotEmpty())
            {
                return Builds.Where(b => b.Status.Equals("building", StringComparison.OrdinalIgnoreCase));
            }
            else
            {
                return new List<Build>();
            }
        }

        public IEnumerable<Build> GetCompletedBuilds()
        {
            if (Builds.IsNotNullAndNotEmpty())
            {
                return Builds.Where(b => b.Status.Equals("succeeded", StringComparison.OrdinalIgnoreCase) ||
                    b.Status.Equals("failed", StringComparison.OrdinalIgnoreCase));
            }
            else
            {
                return new List<Build>();
            }
        }
    }
}