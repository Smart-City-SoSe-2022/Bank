using Microsoft.AspNetCore.Mvc;

namespace bankbackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : Controller
    {
        // GET: api/Account
        [HttpGet]
        public String Get()
        {
            return "Hello";
        }


        [Route("Get/{id}")]
        [HttpGet]
        // GET: api/Account/Get/5
        public String Get(int id)
        {
            return "Hello" + id;
        }
    }
}
