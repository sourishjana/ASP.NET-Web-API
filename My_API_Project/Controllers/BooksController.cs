using Microsoft.AspNetCore.Mvc;

namespace My_API_Project.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        [HttpGet]
        [Route("{id:int:min(10):max(100)}")]
        public string GetById(int id)
        {
            return "Hello int " + id;
        }

        [HttpGet]
        [Route("api/{idStr:regex(a(b|c))}")] // by default is taken as string
        public string GetByIdString(string idStr)
        {
            return "Hello string " + idStr;
        }
    }
}
