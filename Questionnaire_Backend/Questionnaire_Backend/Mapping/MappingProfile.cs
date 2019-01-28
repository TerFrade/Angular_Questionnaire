using AutoMapper;
using Questionnaire_Backend.Controllers.Resources;
using Questionnaire_Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Questionnaire_Backend.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            /* -Below is an example of mapping complex objects within our main object.
             CreateMap<UserResource, Users>().ForMember(u => u.RolesId, opt => opt.MapFrom(ur => ur.RolesId))
             CreateMap<Roles, RoleResource>().ForMember(ur => ur.RolesId, opt => opt.MapFrom(u => u.RolesId))
            */


            //Domain to API Resource
            CreateMap<Users, UserResource>();
            CreateMap<Roles, RoleResource>();

            //API Resource to Domain
            CreateMap<UserResource, Users>().ForMember(u => u.Id, opt => opt.Ignore());
        }   
    }
}
