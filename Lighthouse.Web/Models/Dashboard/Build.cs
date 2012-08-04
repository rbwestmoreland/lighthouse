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

        public TimeSpan TimeRemaining(TimeSpan averageBuildTime)
        {
            var timeRemaining = TimeSpan.Zero;

            if (Created.HasValue && !Deployed.HasValue)
            {
                var timeCompleted = DateTime.UtcNow - Created.Value;
                timeRemaining = averageBuildTime - timeCompleted;
            }

            return timeRemaining;
        }

        public int PercentComplete(TimeSpan averageBuildTime)
        {
            var percentComplete = 100;

            if (Created.HasValue && !Deployed.HasValue)
            {
                var timeCompleted = DateTime.UtcNow - Created.Value;
                var absolutePercentComplete = (timeCompleted.TotalSeconds / averageBuildTime.TotalSeconds) * 100;
                percentComplete = (int)Math.Round(absolutePercentComplete, MidpointRounding.AwayFromZero);
            }

            return percentComplete;
        }
    }
}