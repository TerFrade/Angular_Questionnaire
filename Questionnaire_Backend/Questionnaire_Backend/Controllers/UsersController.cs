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
    [Route("/api/users")]
    public class UsersController : Controller
    {
        private readonly QuestionnaireDbContext _context;
        private readonly IMapper mapper;

        public UsersController(QuestionnaireDbContext context, IMapper mapper)
        {
            this._context = context;
            this.mapper = mapper;
        }

        // GET: All Users
        [HttpGet]
        public UserResource[] Get()
        {
            
                return _context.Users.ToArray()
                   .Select(x => new UserResource()).ToArray();
            
        }

        // GET: A Users
        [HttpGet("{email}")]
        public async Task<IActionResult> GetUser(string email)
        {
            var user = await _context.Users.FromSql("Select * from Users where email ='"+email+"'").FirstAsync();

            if (user == null)
                return NotFound();

            return Ok(mapper.Map<Users, UserResource>(user));
        }

        //POST: A New User
        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] UserResource userResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = mapper.Map<UserResource, Users>(userResource);
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            var result = mapper.Map<Users, UserResource>(user);
            return Ok(result);
        }

        //PUT: Update A User
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] UserResource userResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = await _context.Users.FindAsync(id);

            if (user == null)
                return NotFound();

            mapper.Map<UserResource, Users>(userResource, user);
            await _context.SaveChangesAsync();

            var result = mapper.Map<Users, UserResource>(user);
            return Ok(result);
        }

        //DELETE: Delete A User
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
                return NotFound();

            _context.Remove(user);
            await _context.SaveChangesAsync();

            return Ok(id);
        }

    }
}
