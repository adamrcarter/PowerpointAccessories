using System;
using DocumentFormat.OpenXml.Drawing;
using System.Collections.Generic;
using System.Text;

namespace PowerpointAccessories.Issues
{
    public class VideoIssueItem : IssueItem
    {


        public VideoIssueItem(string videoFileName, VideoFromFile relationshipID, string Description = "empty", bool IsFixable = false, bool IsChecked = false) : base(Description, IsFixable, IsChecked)
        {
            
            VideoFileName = videoFileName;
            RelationshipID = relationshipID;
        }

        public VideoFromFile RelationshipID { get; set; }

        public string VideoFileName { get; set; }

        public Boolean IsEmbedded { get; set; }


    }
}

