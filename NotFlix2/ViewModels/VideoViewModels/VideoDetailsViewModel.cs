using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotFlix2.ViewModels.VideoViewModels
{
    public class VideoDetailsViewModel
    {
        public Guid Id { get; set; }
        public string VideoName { get; set; }
        public string VideoUrl { get; set; }
        public string VideoPrice { get; set; }
        public string VideoGender { get; set; }
    }
}
