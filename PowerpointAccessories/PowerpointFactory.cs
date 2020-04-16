using PowerpointAccessories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PowerpointAccessories
{
    public class PowerpointFactory
    {
        public static IPowerpoint GetPowerpoint(string filepath)
        {
            return new Powerpoint(filepath);
        }
        public static IPowerpoint GetPowerpoint(Stream stream)
        {
            return new Powerpoint(stream);
        }
    }
}
