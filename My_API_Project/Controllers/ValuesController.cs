using Microsoft.AspNetCore.Mvc;

namespace My_API_Project.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ValuesController : ControllerBase
    {
        [HttpGet]
        [Route("~/api/get-all")] // if we donot want to use the default base url
        public string getAll()
        {
            return "hello from getAll";
        }

        [HttpGet]
        public string getAllAuthors()
        {
            return "hello from getAllAuthors";
        }

        // working with variables in routing
        [HttpGet]
        [Route("{id}")]
        public string getById(int id)
        {
            return "Hello " + id;
        }

        [HttpGet]
        [Route("{id}/author/{authorId}")]
        public string getAuthorById(int id,int authorId)
        {
            return "AuthorId: " + authorId + " Id: " + id;
        }

        // working with query string in routing
        [HttpGet]
        public string search(int? id, int? authorId,string name,int? rating,int? price)
        {
            return "Hello from Search ";
        }


        // multiple URLs fro single resource
        [HttpGet]
        public string multiUrl()
        {
            return "hello from getAll";
        }

        // same URL for multiple resouces is not possible


        // Token replacement in routing
        [HttpGet]
        
        public string token()
        {
            return "Token";
        }
    }
}
