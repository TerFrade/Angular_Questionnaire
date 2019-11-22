using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using Questionnaire_BackendV3.Database.Models;
using Questionnaire_BackendV3.DTO;
using Questionnaire_BackendV3.Models;

namespace Questionnaire_BackendV3.Controllers
{
    public class QuestionsController : ApiController
    {

        // GET: api/Roles
        public QuestionDTO[] Get()
        {
            using (var db = new QuestionnaireDBContext())
            {
                return db.Questions.ToArray()
                   .Select(x => new QuestionDTO(x)).ToArray();
            }
        }

        public int Post([FromBody] QuestionDTO value)
        {
            using (var db = new QuestionnaireDBContext())
            {
                var item = new Question()
                {
                    QuestionText = value.QuestionText,
                    Index = value.Index,
                    IsRequired = value.IsRequired,
                    Picture = value.Picture,
                    QuestionnaireId = value.QuestionnaireId,
                    Questionnaire = db.Questionnaires.FirstOrDefault(x => x.Id == value.QuestionnaireId),
                    QuestionTypeId = value.QuestionTypeId,
                    QuestionType = db.QuestionTypes.FirstOrDefault(x => x.Id == value.QuestionTypeId),
                    AvailableAnswers = value.AvailableAnswers != null ? value.AvailableAnswers
                    .Select(x => new AvailableAnswer()
                    {
                        AnswerText = x.AnswerText ?? ""
                    }).ToList() : null
                };
            
                db.Questions.Add(item);
                db.SaveChanges();
                return item.Id;
            }
        }

        public void Put(int id, [FromBody] QuestionDTO value)
        {
            using (var db = new QuestionnaireDBContext())
            {
                var item = db.Questions.FirstOrDefault(x => x.Id == id);
                if (item == null) { throw new HttpResponseException(HttpStatusCode.NotFound); }
                item.QuestionText = value.QuestionText;
                item.Index = value.Index;
                item.IsRequired = value.IsRequired;
                item.Picture = value.Picture;
                item.QuestionnaireId = value.QuestionnaireId;
                item.Questionnaire = db.Questionnaires.FirstOrDefault(x => x.Id == value.QuestionnaireId);
                item.QuestionTypeId = value.QuestionTypeId;
                item.QuestionType = db.QuestionTypes.FirstOrDefault(x => x.Id == value.QuestionTypeId);
                item.AvailableAnswers = value.AvailableAnswers != null ? value.AvailableAnswers
                    .Select(x => new AvailableAnswer()
                    {
                        AnswerText = x.AnswerText
                    }).ToList() : null;
                db.SaveChanges();
            }
        }

        public void Put([FromBody] QuestionDTO value)
        {
            using (var db = new QuestionnaireDBContext())
            {
                var item = db.Questions.FirstOrDefault(x => x.Id == value.Id);
                if (item == null) { throw new HttpResponseException(HttpStatusCode.NotFound); }
                item.QuestionText = value.QuestionText;
                item.Index = value.Index;
                item.IsRequired = value.IsRequired;
                item.Picture = value.Picture;
                item.QuestionnaireId = value.QuestionnaireId;
                item.Questionnaire = db.Questionnaires.FirstOrDefault(x => x.Id == value.QuestionnaireId);
                item.QuestionTypeId = value.QuestionTypeId;
                item.QuestionType = db.QuestionTypes.FirstOrDefault(x => x.Id == value.QuestionTypeId);
                item.AvailableAnswers = value.AvailableAnswers != null ? value.AvailableAnswers
                    .Select(x => new AvailableAnswer()
                    {
                        AnswerText = x.AnswerText
                    }).ToList() : null;
                db.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (var db = new QuestionnaireDBContext())
            {
                var item = db.Questions.FirstOrDefault(x => x.Id == id);
                if (item == null) { return; }
                db.Questions.Remove(item);
                db.SaveChanges();
            }
        }
    }
}