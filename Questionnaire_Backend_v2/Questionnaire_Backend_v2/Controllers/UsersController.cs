using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using System.Threading.Tasks;
using Questionnaire_Backend_v2.Database.Models;
using Questionnaire_Backend_v2.DTO;
using Questionnaire_Backend_v2.Models;

namespace Questionnaire_Backend_v2.Controllers
{
    public class UsersController : ApiController
    {
        private readonly QuestionnaireDBv2Context _db = new QuestionnaireDBv2Context();
        // GET: api/Users
        public UserDTO[] GetUsers()
        {
            using (var db = new QuestionnaireDBv2Context())
            {
                return db.Users.Include(r => r.Role).ToArray()
                   .Select(x => new UserDTO(x)).ToArray();
            }
        }

        // GET: api/Users?email=[email]&password=[password]
        public async Task<UserDTO> GetUserByEmailAndPassword(string email, string password)
        {
            using (var db = new QuestionnaireDBv2Context())
            {
                var item = await db.Users.Include(r => r.Role).FirstOrDefaultAsync(x => x.Email == email && x.Password == password);
                if (item == null) { throw new HttpResponseException(HttpStatusCode.NotFound); }
                return new UserDTO(item);
            }
        }

        // GET: api/Users/5
        public async Task<UserDTO> GetUserEmail(string Id)
        {
            using (var db = new QuestionnaireDBv2Context())
            {
                var item = await db.Users.Include(r => r.Role).FirstOrDefaultAsync(x => x.Email == Id);
                if (item == null) { throw new HttpResponseException(HttpStatusCode.NotFound); }
                return new UserDTO(item);
            }
        }

        // PUT: api/Users/5
        public void Put(int id, [FromBody] UserDTO value)
        {
            using (var db = new QuestionnaireDBv2Context())
            {
                var item = db.Users.Include(r => r.Role).FirstOrDefault(x => x.Id == id);
                if (item == null) { throw new HttpResponseException(HttpStatusCode.NotFound); }
                item.Username = value.Username;
                item.Email = value.Email;
                item.Password = value.Password;
                item.RoleId = db.Roles.Single(r => r.Id == value.RoleId).Id;

                db.SaveChanges();
            }
        }

        // POST: api/Users
        [ResponseType(typeof(User))]
        public int PostUser([FromBody] UserDTO value)
        {
            using (var db = new QuestionnaireDBv2Context())
            {
                var item = new User()
                {
                    Username = value.Username,
                    Email = value.Email,
                    Password = value.Password,
                    RoleId = db.Roles.Single(r => r.Id == value.RoleId).Id
            };
                
                db.Users.Add(item);
                db.SaveChanges();
                return item.Id;
            }
        }

        // DELETE: api/Users/5
        public void Delete(int id)
        {
            using (var db = new QuestionnaireDBv2Context())
            {
                var item = db.Users.FirstOrDefault(x => x.Id == id);
                if (item == null) { return; }
                db.Users.Remove(item);
                db.SaveChanges();
            }
        }

    }
}