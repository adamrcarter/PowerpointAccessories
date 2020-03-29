using System;
using System.Collections.Generic;
using System.Text;

namespace PowerpointAccessories
{
    public interface IIssueScanner
    {
        public IPowerpoint powerpoint { get; }

        public void Scan();


    }
}
