using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CourseProject.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CourseProject.Controllers
{
    public class CoursesController : ApiController
    {
        static List<Course> courses = new List<Course>()
        {
            new Course() {CourseId = 1, CourseName="Android",Trainer="Shawn",Fees=12000,
                          CourseDescription = "Android is a mobile Operating system development"},

            new Course() {CourseId = 2, CourseName="Asp.net",Trainer="Kevin",Fees=10000,
                          CourseDescription = "Asp.net is a open source web development framework"},

            new Course() {CourseId = 3, CourseName="Jsp",Trainer="Debaratha",Fees=10000,
                          CourseDescription = "Java server pages is a technology used for web page creations"},

            new Course() {CourseId = 4, CourseName="Xamarin.forms",Trainer="Mark John",Fees=15000,
                          CourseDescription = "Xamarin forms are cross platform UI tools"}

        };

        [HttpGet]
        public HttpResponseMessage Get(string courseName)
        {
            var course = courses.SingleOrDefault(c => c.CourseName == courseName);
            if (course == null) return Request.CreateResponse(HttpStatusCode.NotFound, "Course Name " + courseName + " not found");
            else
            {
                var response = Request.CreateResponse(HttpStatusCode.OK);
                response.Content = new StringContent(JsonConvert.SerializeObject(course), System.Text.Encoding.UTF8, "application/json");
                return response;
            }
        }

        [HttpPost]
        public HttpResponseMessage Post([FromBody]Course course)
        {
            courses.Add(course);
            var response = Request.CreateResponse(HttpStatusCode.Created);
            response.Content = new StringContent(JsonConvert.SerializeObject(course), System.Text.Encoding.UTF8, "application/json");
            return response;
        }
    }
}
