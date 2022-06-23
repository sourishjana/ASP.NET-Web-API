using CourseProject.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CourseProject.Controllers
{
    public class BrandsController : ApiController
    {
        static List<Brand> brands = new List<Brand>()
        {
            new Brand(){BrandId="B001",Name="Haro"},
            new Brand(){BrandId="B002",Name="Electra"},
            new Brand{BrandId="B003",Name="Heller"},
            new Brand{BrandId="B004",Name="Trek"}
        };

        [HttpPost]
        public HttpResponseMessage Post([FromUri]Brand brand)
        {
            brands.Add(brand);
            var response = Request.CreateResponse(HttpStatusCode.Created);
            response.Content = new StringContent(JsonConvert.SerializeObject(brand), System.Text.Encoding.UTF8, "application/json");
            return response;
        }
    }
}
