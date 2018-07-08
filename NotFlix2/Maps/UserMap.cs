using AutoMapper;
using Notflix.Domain;
using NotFlix.DataTransferObjects.User;
using NotFlix2.ViewModels.AccountViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotFlix2.Maps
{
    public class UserMap : Profile
    {
        public UserMap()
        {
            CreateMap<User, UserDto>();
            CreateMap<UserDto, LoginResultViewModel>();
         
        }
    }
}
