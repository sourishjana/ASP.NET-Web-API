using LearnTodayWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LearnTodayWebAPI.Controllers
{
    public class StudentController : ApiController
    {
        public LearnTodayWebAPIDbContext context { get; set; }
        public StudentController()
        {
            context = new LearnTodayWebAPIDbContext();
        }
        [HttpGet]
        public IEnumerable<Course> GetAllCourses()
        {
            return context.Courses.OrderBy(c => c.Start_Date);
        }
        [HttpPost]
        public HttpResponseMessage PostStudent([FromBody]Student student)
        {
            try
            {
                context.Students.Add(student);
                context.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.Created);
            }
            catch(Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
        [HttpDelete]
        public HttpResponseMessage DeleteStudentEnrollment(int id)
        {
            try
            {
                var student = context.Students.Find(id);
                if (student == null) return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No enrollement information found");
                context.Students.Remove(student);
                context.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch(Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

    }
}
