using AutoMapper;
using NotFlix.DataTransferObjects.Video;
using NotFlix2.ViewModels.VideoViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotFlix2.Maps
{
    public class VideoMap : Profile
    {
        public VideoMap()
        {
            CreateMap<VideoDto, VideoDetailsViewModel>();
        }
    }
}
