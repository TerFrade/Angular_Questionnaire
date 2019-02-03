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
using Questionnaire_BackendV3.Database.Models;
using Questionnaire_BackendV3.DTO;
using Questionnaire_BackendV3.Models;

namespace Questionnaire_BackendV3.Controllers
{
    public class UsersController : ApiController
    {

        // GET: api/Roles
        public UserDTO[] Get()
        {
            using (var db = new QuestionnaireDBContext())
            {
                return db.Users.ToArray()
                   .Select(x => new UserDTO(x)).ToArray();
            }
        }

        public int Post([FromBody] UserDTO value)
        {
            using (var db = new QuestionnaireDBContext())
            {
                var item = new User()
                {
                    Email = value.Email,
                    Username = value.Username,
                    Password = value.Password,
                    RoleId = value.RoleId,
                    Role = db.Roles.FirstOrDefault(x => x.Id == value.RoleId),
                    Questionnaires = value.Questionnaires != null ? value.Questionnaires
                    .Select(x => new Questionnaire()
                    {
                        Title = x.Title,
                        Description = x.Description,
                        IsPublic = x.IsPublic,
                        Link = x.Link

                    }).ToList() : null
                };
                db.Users.Add(item);
                db.SaveChanges();
                return item.Id;
            }
        }

        public void Put(int id, [FromBody] UserDTO value)
        {
            using (var db = new QuestionnaireDBContext())
            {
                var item = db.Users.FirstOrDefault(x => x.Id == id);
                if (item == null) { throw new HttpResponseException(HttpStatusCode.NotFound); }
                item.Email = value.Email;
                item.Username = value.Username;
                item.Password = value.Password;
                item.RoleId = value.RoleId;
                item.Role = db.Roles.FirstOrDefault(x => x.Id == value.RoleId);
                db.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (var db = new QuestionnaireDBContext())
            {
                var item = db.Users.FirstOrDefault(x => x.Id == id);
                if (item == null) { return; }
                db.Users.Remove(item);
                db.SaveChanges();
            }
        }

    }
}