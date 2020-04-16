using System;
using System.Collections.Generic;
using System.Text;

namespace PowerpointAccessories.Issues
{
    public abstract class IssueItem : IIssue
    {
        public IssueItem(string Description = "empty", bool IsFixable = false, bool IsFixed = false)
        {
            this._description = Description;
            this._isFixable = IsFixable;
            this._isFixed = IsFixed;
            Type = this.GetType().Name;
        }

        private string _description;
        private bool _isFixed;
        private bool _isFixable;
        public string Type { get; }

        public string Description
        {
            get
            {
                return _description;
            }
            set
            {
                _description = value;
            }

        }

        public bool IsFixable {
            get
            {
                return _isFixable;
            }
            set
            {
                _isFixable = value;
            }
        }

        public bool IsFixed
        {
            get
            {
                return _isFixed;
            }
            set
            {
                _isFixed = value;
            }
        }



    }
}
