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
    public class QuestionTypesController : ApiController
    {

        // GET: api/Roles
        public QuestionTypeDTO[] Get()
        {
            using (var db = new QuestionnaireDBContext())
            {
                return db.QuestionTypes.ToArray()
                   .Select(x => new QuestionTypeDTO(x)).ToArray();
            }
        }

        public QuestionTypeDTO Get(int id)
        {
            using (var db = new QuestionnaireDBContext())
            {
                var item = db.QuestionTypes.FirstOrDefault(x => x.Id == id);
                if (item == null) { throw new HttpResponseException(HttpStatusCode.NotFound); }
                return new QuestionTypeDTO(item);
            }
        }

        public int Post([FromBody] QuestionTypeDTO value)
        {
            using (var db = new QuestionnaireDBContext())
            {
                var item = new QuestionType()
                {
                    TypeName = value.TypeName
                };
                db.QuestionTypes.Add(item);
                db.SaveChanges();
                return item.Id;
            }
        }

        public void Put(int id, [FromBody] QuestionTypeDTO value)
        {
            using (var db = new QuestionnaireDBContext())
            {
                var item = db.QuestionTypes.FirstOrDefault(x => x.Id == id);
                if (item == null) { throw new HttpResponseException(HttpStatusCode.NotFound); }
                item.TypeName = value.TypeName;
                db.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (var db = new QuestionnaireDBContext())
            {
                var item = db.QuestionTypes.FirstOrDefault(x => x.Id == id);
                if (item == null) { return; }
                db.QuestionTypes.Remove(item);
                db.SaveChanges();
            }
        }
    }
}