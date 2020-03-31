using DocumentFormat.OpenXml.Presentation;
using System;
using System.Collections.Generic;
using System.Text;

namespace PowerpointAccessories.Issues
{
    public class AutoTransitionIssue : TransitionIssue
    {
        public int Duration { get; private set; }
        public AutoTransitionIssue(int duration, Transition transitionElement, string Description = "empty", bool IsFixable = false, bool IsChecked = false) : base(transitionElement, Description, IsFixable, IsChecked)
        {
            Duration = duration;

        }
    }
}
