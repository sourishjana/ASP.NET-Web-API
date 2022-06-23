using StudentService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace StudentService.Controllers
{
    public class StudentsController : ApiController
    {
        public HttpResponseMessage Post([FromBody]Student student)
        {
            try
            {
                using (StudentDBContext dbContext = new StudentDBContext())
                {
                    dbContext.Students.Add(student);
                    dbContext.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.Created, student);
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
            
        }
    }
}
