
using System.Collections.Generic;
using System.IO;

namespace PowerpointAccessories
{
    public class Powerpoint : IPowerpoint
    {
        public string FilePath { get; }
        public Stream Stream { get; set; }
        public IDictionary<string, SlideModel> slides { get; set; }

        public Powerpoint(string filePath)
        {
            FilePath = filePath;
            slides = new Dictionary<string, SlideModel>();
            
        }
        public Powerpoint()
        {
            
        }
        public Powerpoint(Stream stream)
        {
            Stream = stream;
            slides = new Dictionary<string, SlideModel>();
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
