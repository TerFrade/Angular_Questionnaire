using System.Data;
using System.Linq;
using System.Net;
using System.Web.Http;
using Questionnaire_BackendV3.Database.Models;
using Questionnaire_BackendV3.DTO;
using Questionnaire_BackendV3.Models;

namespace Questionnaire_BackendV3.Controllers
{
    public class QuestionnairesController : ApiController
    {
        // GET: api/Roles
        public QuestionnaireDTO[] Get()
        {
            using (var db = new QuestionnaireDBContext())
            {
                return db.Questionnaires.ToArray()
                   .Select(x => new QuestionnaireDTO(x)).ToArray();
            }
        }

        public int Post([FromBody] QuestionnaireDTO value)
        {
            using (var db = new QuestionnaireDBContext())
            {
                var item = new Questionnaire()
                {
                    Title = value.Title,
                    Description = value.Description,
                    IsPublic = value.IsPublic,
                    Link = value.Link,
                    UserId = value.UserId,
                    User = db.Users.FirstOrDefault(x => x.Id == value.UserId),
                };
                db.Questionnaires.Add(item);
                db.SaveChanges();
                return item.Id;
            }
        }

        public void Put(int id, [FromBody] QuestionnaireDTO value)
        {
            using (var db = new QuestionnaireDBContext())
            {
                var item = db.Questionnaires.FirstOrDefault(x => x.Id == id);
                if (item == null) { throw new HttpResponseException(HttpStatusCode.NotFound); }
                item.Title = value.Title;
                item.Description = value.Description;
                item.IsPublic = value.IsPublic;
                item.Link = value.Link;
                item.UserId = value.UserId;
                item.User = db.Users.FirstOrDefault(x => x.Id == value.UserId);
                db.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (var db = new QuestionnaireDBContext())
            {
                var item = db.Questionnaires.FirstOrDefault(x => x.Id == id);
                if (item == null) { return; }
                db.Questionnaires.Remove(item);
                db.SaveChanges();
            }
        }
    }
}