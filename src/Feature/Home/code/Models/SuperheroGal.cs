using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Trn.Feature.Home.Models
{
    public class SuperheroGal
    {
        public HtmlString SuperheroImageGallery { get; set; }

        public string ImageAlt { get; set; }
        public string ImageSrc { get; set; }

        public string ImageIsActive { get; set; }
    }
}