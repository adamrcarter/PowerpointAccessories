using PowerpointAccessories;
using System;
using System.Collections.Generic;
using System.Text;

namespace PowerpointAccessories
{
    public class PowerpointFactory
    {
        public static IPowerpoint GetPowerpoint(string filepath)
        {
            return new Powerpoint(filepath);
        }
        public static IPowerpoint GetPowerpoint()
        {
            return new Powerpoint();
        }
    }
}
