using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Drawing;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Presentation;
using PowerpointAccessories.Issues;


namespace PowerpointAccessories
{
    /// <summary>
    /// The IssueScanner Class
    /// Will scan powerpoint XML data to find issues and create Issue objects while adding them to the powerpoint Object
    /// </summary>
    public class IssueScanner : IIssueScanner
    {

        public IPowerpoint powerpoint { get; }
        private string[] Win10Fonts;

        public IssueScanner(IPowerpoint powerpoint)
        {
            this.powerpoint = powerpoint;
            Win10Fonts = File.ReadAllLines("./Win10Fonts.txt");
        }

        public void Close()
        {

        }


        public void Scan() 
        {
            try
            {
                if (this.powerpoint.Stream == null)
                {
                    this.powerpoint.Stream = File.Open(this.powerpoint.FilePath, FileMode.Open);
                }
                using PresentationDocument document = PresentationDocument.Open(this.powerpoint.Stream, true);
                SlidePart slidePart;
                var presentation = document.PresentationPart.Presentation;
                List<EmbeddedFont> embeddedFonts = document.PresentationPart.Presentation.Descendants<EmbeddedFont>().ToList();
                //Console.WriteLine("Loaded");
                foreach (SlideId slideId in presentation.SlideIdList)
                {
                    slidePart = document.PresentationPart.GetPartById(slideId.RelationshipId) as SlidePart;
                    if (slidePart == null || slidePart.Slide == null)
                    {
                        continue;
                    }
                    string currentSlideRelID = slideId.RelationshipId.Value;
                    SlideModel slidemodel = CreateNewSlide(currentSlideRelID);
                    Slide slide = slidePart.Slide;
                    CheckIssues(slide, currentSlideRelID, slidePart, document, embeddedFonts);
                }
                document.Close();
                this.powerpoint.Stream.Close();
            }
            catch (FileNotFoundException)
            {
                
                Console.WriteLine("Opps, we could not find the presentation you were referencing. Try again....");
            }
        }

        private void CheckIssues(Slide slide, String currentSlideRelID, SlidePart slidePart, PresentationDocument document, List<EmbeddedFont> embeddedFonts)
        {
            CheckForVideo(slide, currentSlideRelID, slidePart, document);
            CheckTransitionIssues(slide, currentSlideRelID, document);
            CheckForNonStandardFonts(slide, currentSlideRelID, document, embeddedFonts);
        }

        private SlideModel CreateNewSlide(string id)
        {
            SlideModel slide = new SlideModel(SlideModel.rIdtoSlideIndex(id));
            this.powerpoint.addToSlideList(id, slide);
            return slide;
        }

        private void CheckForVideo(Slide slide, String currentSlideRelID, SlidePart slidePart, PresentationDocument document)
        {
            var videos = slide.Descendants<VideoFromFile>();

            foreach (VideoFromFile video in videos)
            {
                String path = slidePart.GetReferenceRelationship(video.Link).Uri.OriginalString;
                String fileExtension = System.IO.Path.GetExtension(path);
                String description = $"Found video issue on slide {SlideModel.rIdtoSlideIndex(currentSlideRelID)}, file extension is {fileExtension}";
                Boolean fixable;
                String filename = System.IO.Path.GetFileName(path);
                if (fileExtension == ".mp4") { fixable = false; }
                else
                {
                    fixable = true;

                }
                IIssue issue = new VideoIssueItem(filename, video, description, fixable);
                powerpoint.slides[currentSlideRelID].addToIssueList(issue);
            }

        }


        private void CheckTransitionIssues(Slide slide, String currentSlideRelID, PresentationDocument document)
        {
            var transitionElements = slide.Descendants<Transition>();
            foreach (var transitionElement in transitionElements)
            {
                CheckForAutoTransition(currentSlideRelID, transitionElement);
                CheckForNoMouseClickTransition(currentSlideRelID, transitionElement);
            }
        }

        private void CheckForNoMouseClickTransition(string currentSlideRelID, Transition transitionElement)
        {
            if (!(transitionElement.Parent.GetType() == typeof(AlternateContentFallback)))
            {
                var attribute = transitionElement.GetAttributes().Where(x => x.LocalName == "advClick").FirstOrDefault();
                if (attribute.Value != null && attribute.Value == "0")
                {
                    IIssue issue = new NoClickTransitionIssue(transitionElement, $"Found no click transition issue on {SlideModel.rIdtoSlideIndex(currentSlideRelID)}", true);
                    powerpoint.slides[currentSlideRelID].addToIssueList(issue);
                }
            }
        }

        private void CheckForAutoTransition(string currentSlideRelID, Transition transitionElement)
        {
            if (!(transitionElement.Parent.GetType() == typeof(AlternateContentFallback)))
            {
                var attribute = transitionElement.GetAttributes().Where(x => x.LocalName == "advTm").FirstOrDefault();
                if (attribute.Value != null)
                {
                    IIssue issue = new AutoTransitionIssue(Int32.Parse(attribute.Value), transitionElement, $"Found auto transition on {SlideModel.rIdtoSlideIndex(currentSlideRelID)} duration: {attribute.Value} ", true);
                    powerpoint.slides[currentSlideRelID].addToIssueList(issue);
                }
            }

        }

        private void CheckForNonStandardFonts(Slide slide, string currentSlideRelID, PresentationDocument document, List<EmbeddedFont> embeddedFonts)
        {
            
            foreach(LatinFont font in slide.Descendants<LatinFont>())
            {
                if (Win10Fonts.FirstOrDefault( x=> x == font.Typeface.Value.ToLower()) == null && embeddedFonts.FirstOrDefault(x=> x.Font.Typeface.Value.ToLower() == font.Typeface.Value.ToLower()) == null)
                {
                    string fontname = font.Typeface.Value;
                    IIssue issue = new FontIssue(null, font.Typeface.Value, $"A non-standard powerpoint font - {font.Typeface.Value} was found and is not embedded", true, true);
                    powerpoint.slides[currentSlideRelID].addToIssueList(issue);
                }
            }
            

        }

    }
}
