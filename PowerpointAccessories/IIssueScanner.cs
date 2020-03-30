using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PowerpointAccessories
{
    public interface IIssueScanner
    {
        public IPowerpoint powerpoint { get; }

        public void Scan();


        public void Close();



    }
}
