using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Questionnaire_Backend.Controllers.Resources;
using Questionnaire_Backend.Models;

namespace Questionnaire_Backend.Controllers
{
    public class UsersController : Controller
    {
        private readonly QuestionnaireDbContext _context;
        private readonly IMapper mapper;

        public UsersController(QuestionnaireDbContext context, IMapper mapper)
        {
            this._context = context;
            this.mapper = mapper;
        }

        // GET: Users
        [HttpGet("/api/users")]
        public async Task<IEnumerable<UserResource>> GetUsers()
        {
            var users = await _context.Users.Include(u => u.Roles).ToListAsync();

            return mapper.Map<List<Users>, List<UserResource>>(users);
        }

    }
}
