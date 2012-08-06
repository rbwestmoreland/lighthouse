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

        public TimeSpan TimeRemaining(TimeSpan averageBuildTime, DateTime utcNow)
        {
            if (!Created.HasValue)
            {
                return TimeSpan.Zero;
            }

            if (Deployed.HasValue)
            {
                return TimeSpan.Zero;
            }

            if (averageBuildTime <= TimeSpan.Zero)
            {
                return TimeSpan.Zero;
            }

            if (utcNow < Created.Value)
            {
                return TimeSpan.Zero;
            }

            var timeCompleted = utcNow - Created.Value;
            var timeRemaining = averageBuildTime - timeCompleted;

            return timeRemaining;
        }

        public int PercentComplete(TimeSpan averageBuildTime, DateTime utcNow)
        {
            if (!Created.HasValue)
            {
                return 0;
            }

            if (Deployed.HasValue)
            {
                return 100;
            }

            if (averageBuildTime <= TimeSpan.Zero)
            {
                return 100;
            }

            if (utcNow < Created.Value)
            {
                return 0;
            }

            var timeCompleted = utcNow - Created.Value;
            var absolutePercentComplete = (timeCompleted.TotalSeconds / averageBuildTime.TotalSeconds) * 100;
            var percentComplete = (int)Math.Round(absolutePercentComplete, MidpointRounding.AwayFromZero);

            return percentComplete;
        }

        public bool IsSuccessful()
        {
            return Status != null && Status.Equals("succeeded", StringComparison.OrdinalIgnoreCase);
        }
    }
}