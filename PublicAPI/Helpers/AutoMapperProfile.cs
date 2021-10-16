using ApplicationCore.Entities;
using AutoMapper;
using PublicAPI.Models;
using PublicAPI.Models.MentionModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PublicAPI.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserModel>();
            CreateMap<RegisterModel, User>();
            CreateMap<UpdateModel, User>();

            CreateMap<Mention, MentionModel>();
            CreateMap<MentionCreateModel, Mention>();
            CreateMap<MentionUpdateModel, Mention>();
        }
    }
}
