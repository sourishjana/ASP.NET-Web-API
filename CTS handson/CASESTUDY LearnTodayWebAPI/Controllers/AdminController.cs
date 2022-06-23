using LearnTodayWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LearnTodayWebAPI.Controllers
{
    public class AdminController : ApiController
    {
        public LearnTodayWebAPIDbContext context { get; set; }
        public AdminController()
        {
            context = new LearnTodayWebAPIDbContext();
        }
        [HttpGet]
        public HttpResponseMessage GetAllCourses()
        {
            return Request.CreateResponse(HttpStatusCode.OK, context.Courses.ToList());
        }
        [HttpGet]
        public HttpResponseMessage GetCourseById(int id)
        {
            var course = context.Courses.Find(id);
            if (course == null) return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Searched Data not Found");
            return Request.CreateResponse(HttpStatusCode.Created, course);
        }
    }
}
