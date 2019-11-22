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
    public class ResponsesController : ApiController
    {
        // GET: api/Roles
        public ResponseDTO[] Get()
        {
            using (var db = new QuestionnaireDBContext())
            {
                return db.Responses.ToArray()
                   .Select(x => new ResponseDTO(x)).ToArray();
            }
        }

        public int Post([FromBody] ResponseDTO value)
        {
            using (var db = new QuestionnaireDBContext())
            {
                var item = new Response()
                {
                    ResponseText = value.ResponseText,
                    QuestionId = value.QuestionId,
                    Question = db.Questions.FirstOrDefault(x => x.Id == value.QuestionId)
                };
                db.Responses.Add(item);
                db.SaveChanges();
                return item.Id;
            }
        }

        public void Put(int id, [FromBody] ResponseDTO value)
        {
            using (var db = new QuestionnaireDBContext())
            {
                var item = db.Responses.FirstOrDefault(x => x.Id == id);
                if (item == null) { throw new HttpResponseException(HttpStatusCode.NotFound); }
                item.ResponseText = value.ResponseText;
                item.QuestionId = value.QuestionId;
                item.Question = db.Questions.FirstOrDefault(x => x.Id == value.QuestionId);
                db.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (var db = new QuestionnaireDBContext())
            {
                var item = db.Responses.FirstOrDefault(x => x.Id == id);
                if (item == null) { return; }
                db.Responses.Remove(item);
                db.SaveChanges();
            }
        }
    }
}