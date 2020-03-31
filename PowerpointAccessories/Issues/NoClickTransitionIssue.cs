using DocumentFormat.OpenXml.Presentation;
using System;
using System.Collections.Generic;
using System.Text;

namespace PowerpointAccessories.Issues
{
    class NoClickTransitionIssue : TransitionIssue
    {
        public NoClickTransitionIssue(Transition transitionElement, string Description = "empty", bool IsFixable = false, bool IsChecked = false) : base(transitionElement, Description, IsFixable, IsChecked)
        {

        }
    }
}
