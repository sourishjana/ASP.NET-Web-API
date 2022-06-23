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
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                using (StudentDBContext dbContext = new StudentDBContext())
                {
                    var entity = dbContext.Students.FirstOrDefault(s => s.ID == id);
                    if (entity == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, $"Student with id {id} not found to delete.");
                    }
                    else
                    {
                        dbContext.Students.Remove(entity);
                        dbContext.SaveChanges();
                        return Request.CreateResponse(HttpStatusCode.OK,$"Student with id {id} deleted.");
                    }
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
            
        }
    }
}
