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
    public class RolesController : ApiController
    {

        // GET: api/Roles
        public RoleDTO[] Get()
        {
            using (var db = new QuestionnaireDBContext())
            {
                return db.Roles.ToArray()
                   .Select(x => new RoleDTO(x)).ToArray();
            }
        }

        public RoleDTO Get(int id)
        {
            using (var db = new QuestionnaireDBContext())
            {
                var item = db.Roles.FirstOrDefault(x => x.Id == id);
                if (item == null) { throw new HttpResponseException(HttpStatusCode.NotFound); }
                return new RoleDTO(item);
            }
        }

        public int Post([FromBody] RoleDTO value)
        {
            using (var db = new QuestionnaireDBContext())
            {
                var item = new Role()
                {
                    Name = value.Name,
                    Users = value.Users != null ? value.Users
                      .Select(x => new User() {
                          Email = x.Email,
                          Username = x.Username,
                          Password = x.Password
                      })
                      .ToList() : null
                };
                db.Roles.Add(item);
                db.SaveChanges();
                return item.Id;
            }
        }

        public void Put(int id, [FromBody] RoleDTO value)
        {
            using (var db = new QuestionnaireDBContext())
            {
                var item = db.Roles.FirstOrDefault(x => x.Id == id);
                if (item == null) { throw new HttpResponseException(HttpStatusCode.NotFound); }
                item.Name = value.Name;
                db.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (var db = new QuestionnaireDBContext())
            {
                var item = db.Roles.FirstOrDefault(x => x.Id == id);
                if (item == null) { return; }
                db.Roles.Remove(item);
                db.SaveChanges();
            }
        }
    }
}