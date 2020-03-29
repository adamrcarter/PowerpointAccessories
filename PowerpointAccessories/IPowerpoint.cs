using PowerpointAccessories;
using System;
using System.Collections.Generic;
using System.Text;

namespace PowerpointAccessories
{
    public interface IPowerpoint
    {
        public string FilePath { get; }

        public IDictionary<string, SlideModel> slides { get; set; }

        public int GetNumberOfSlides();

        public void addToSlideList(string Id, SlideModel slide);
    }
}
