using DocumentFormat.OpenXml.Presentation;
using System;
using System.Collections.Generic;
using System.Text;

namespace PowerpointAccessories.Issues
{
    public abstract class TransitionIssue : IssueItem
    {
        public Transition TransitionElement { get; private set; }

        public TransitionIssue(Transition transitionElement, string Description = "empty", bool IsFixable = false, bool IsChecked = false) : base(Description, IsFixable, IsChecked)
        {
            TransitionElement = transitionElement;

        }
    }

}
