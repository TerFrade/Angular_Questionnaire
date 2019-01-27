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
            CreateMap<Users, UserResource>();
            CreateMap<Roles, RoleResource>();
        }
    }
}
