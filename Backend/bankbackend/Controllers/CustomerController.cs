using System.Security.Cryptography;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace bankbackend.Controllers
{

    
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : Controller
    {

        // GET: api/Customer
        [HttpGet]
        public String Get()
        {
            return "Hello";
        }


        [Route("Get/{id}")]
        [HttpGet]
        // GET: api/Customer/Get/5
        public String Get(int id)
        {
            return "Hello"+id;
        }

    }
}
