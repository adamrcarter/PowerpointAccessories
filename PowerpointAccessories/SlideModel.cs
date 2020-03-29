using PowerpointAccessories.Issues;
using System;
using System.Collections.Generic;
using System.Text;

namespace PowerpointAccessories
{
    public class SlideModel
    {
        public int slideId { get; set; }
        public List<IIssue> Issues { get; } 

        public SlideModel(int slideId)
        {
            this.slideId = slideId;
            Issues = new List<IIssue>();
        }

        public SlideModel(int slideId, List<IIssue> issues)
        {
            this.slideId = slideId;
            this.Issues = issues;
        }

        public void addToIssueList(IIssue issue)
        {
            Issues.Add(issue);
        }

        static public int rIdtoSlideIndex(string rId)
        {
            int startIndex = rId.IndexOf("d") + 1;
            return Int16.Parse(rId.Substring(startIndex))-1;
        }


    }
}
