using LearnTodayWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LearnTodayWebAPI.Controllers
{
    public class TrainerController : ApiController
    {
        public LearnTodayWebAPIDbContext context { get; set; }
        public TrainerController()
        {
            context = new LearnTodayWebAPIDbContext();
        }
        [HttpPost]
        public HttpResponseMessage TrainerSignUp([FromBody]Trainer model)
        {
            try
            {
                context.Trainers.Add(model);
                context.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch(Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest,ex);
            }
        }

        [HttpPut]
        public HttpResponseMessage UpdatePassword(int id,[FromBody]Trainer model)
        {
            try
            {
                var trainer = context.Trainers.Find(id);
                if (trainer == null) return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Searched data not found.");
                // trainer.TrainerId = model.TrainerId;
                trainer.Password = model.Password;
                context.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK, "Data updated successfully");
            }
            catch(Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
    }
}
