using Questionnaire_BackendV3.Database.Models;
using Questionnaire_BackendV3.DTO;
using Questionnaire_BackendV3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Questionnaire_BackendV3.Controllers
{
    public class AvailableAnswersController : ApiController
    {
        // GET: api/Roles
        public AvailableAnswerDTO[] Get()
        {
            using (var db = new QuestionnaireDBContext())
            {
                return db.AvailableAnswers.ToArray()
                   .Select(x => new AvailableAnswerDTO(x)).ToArray();
            }
        }

        public int Post([FromBody] AvailableAnswerDTO value)
        {
            using (var db = new QuestionnaireDBContext())
            {
                var item = new AvailableAnswer()
                {
                    AnswerText = value.AnswerText,
                    QuestionId = value.QuestionId,
                    Question = db.Questions.FirstOrDefault(x => x.Id == value.QuestionId)
                };
                db.AvailableAnswers.Add(item);
                db.SaveChanges();
                return item.Id;
            }
        }

        public void Put(int id, [FromBody] AvailableAnswerDTO value)
        {
            using (var db = new QuestionnaireDBContext())
            {
                var item = db.AvailableAnswers.FirstOrDefault(x => x.Id == id);
                if (item == null) { throw new HttpResponseException(HttpStatusCode.NotFound); }
                item.AnswerText = value.AnswerText;
                item.QuestionId = value.QuestionId;
                item.Question = db.Questions.FirstOrDefault(x => x.Id == value.QuestionId);
                db.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (var db = new QuestionnaireDBContext())
            {
                var item = db.AvailableAnswers.FirstOrDefault(x => x.Id == id);
                if (item == null) { return; }
                db.AvailableAnswers.Remove(item);
                db.SaveChanges();
            }
        }
    }
}
