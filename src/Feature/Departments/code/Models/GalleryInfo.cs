using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Trn.Feature.Departments.Models
{
    public class GalleryInfo
    {
        public HtmlString ImageGallery { get; set; }

        public string ImageAlt { get; set; }
        public string ImageSrc { get; set; }

        public string ImageIsActive { get; set; }
        public HtmlString ImageGalleryMainTitle { get; set; }
        public HtmlString ImageGallerySubTitle { get; set; }

    }
}