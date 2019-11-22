using System;
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
        private static Random random = new Random();
        // GET: api/Roles
        public QuestionnaireDTO[] Get()
        {
            using (var db = new QuestionnaireDBContext())
            {
                return db.Questionnaires.ToArray()
                   .Select(x => new QuestionnaireDTO(x)).ToArray();
            }
        }

        public QuestionnaireDTO Get(int id)
        {
            using (var db = new QuestionnaireDBContext())
            {
                var item = db.Questionnaires.FirstOrDefault(x => x.Id == id);
                if (item == null) { throw new HttpResponseException(HttpStatusCode.NotFound); }
                return new QuestionnaireDTO(item);
            }
        }

        public int Post([FromBody] QuestionnaireDTO value)
        {

            int lengthRan = random.Next(5, 9);
             
            using (var db = new QuestionnaireDBContext())
            {
                var item = new Questionnaire()
                {
                    Title = value.Title,
                    Description = value.Description,
                    IsPublic = value.IsPublic,
                    Link = RandomString(lengthRan),
                    UserId = value.UserId,
                    User = db.Users.FirstOrDefault(x => x.Id == value.UserId),
                    //Questions = value.Questions != null ? value.Questions
                    //.Select(x => new Question()
                    //{
                       
                    //    Index = x.Index,
                    //    IsRequired = x.IsRequired,
                    //    Picture = x.Picture,
                    //    QuestionText = x.QuestionText,
                    //    QuestionTypeId = x.QuestionTypeId,
                    //    AvailableAnswers = x.AvailableAnswers != null ? x.AvailableAnswers.Select(y => new AvailableAnswer()
                    //    {
                    //        AnswerText = y.AnswerText
                    //    }).ToList() : null
                    

                    //}).ToList() : null
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

        
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}