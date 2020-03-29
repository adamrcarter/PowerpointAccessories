using PowerpointAccessories;
using PowerpointAccessories.Issues;
using System;
using System.Collections.Generic;
using System.Text;

namespace PowerpointAccessories
{
    public class Powerpoint : IPowerpoint
    {
        public string FilePath { get; }
        public IDictionary<string, SlideModel> slides { get; set; }

        public Powerpoint(string filePath)
        {
            FilePath = filePath;
            slides = new Dictionary<string, SlideModel>();

            
        }
        public Powerpoint()
        {
            
        }

        public int GetNumberOfSlides()
        {
            return slides.Count;
        }

        public void addToSlideList(string Id, SlideModel slide)
        {
            slides.Add(Id, slide);
        }

 
        


    }
}
