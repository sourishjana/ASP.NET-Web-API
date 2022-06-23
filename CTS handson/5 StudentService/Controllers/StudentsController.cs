using Microsoft.AspNetCore.Cors;
using StudentService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace StudentService.Controllers
{
    [EnableCors("http://localhost:4200/")]
    public class StudentsController : ApiController
    {
        [HttpGet]
        public HttpResponseMessage Get()
        {
            using(StudentDBContext dbContext=new StudentDBContext())
            {
                return Request.CreateResponse(HttpStatusCode.OK, dbContext.Students.ToList());
            }
        }

        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            using (StudentDBContext dbContext = new StudentDBContext())
            {
                var entity= dbContext.Students.FirstOrDefault(s => s.ID == id);
                if (entity != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK,entity);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, $"Student with Id {id} not found.");
                }
            }
        }

        [HttpPut]
        public HttpResponseMessage Put(int id, [FromBody] Student student)
        {
            try
            {
                using (StudentDBContext dbContext = new StudentDBContext())
                {
                    var entity = dbContext.Students.FirstOrDefault(s => s.ID == id);
                    if (entity == null) return Request.CreateErrorResponse(HttpStatusCode.NotFound, $"Student with id {id} not found to update.");
                    entity.FirstName = student.FirstName;
                    entity.LastName = student.LastName;
                    entity.Gender = student.Gender;
                    entity.Address = student.Address;
                    dbContext.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.OK, entity);
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }

        }

        [HttpPost]
        public HttpResponseMessage Post([FromBody] Student student)
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

        [HttpDelete]
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
                        return Request.CreateResponse(HttpStatusCode.OK, $"Student with id {id} deleted.");
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
