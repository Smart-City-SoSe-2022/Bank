using Microsoft.AspNetCore.Mvc;

namespace bankbackend.Controllers
{
    public class DebitController : Controller
    {
        [Route("api/[controller]")]
        [ApiController]
        public class CustomerController : Controller
        {

            // GET: api/Debit
            [HttpGet]
            public String Get()
            {
                return "Hello";
            }


            [Route("Get/{id}")]
            [HttpGet]
            // GET: api/Debit/Get/5
            public String Get(int id)
            {
                return "Hello" + id;
            }



            [Route("creat/{accountnumber}/{Balance}")]
            [HttpGet]
            // GET: api/Debit/Get/5
            public String Post(int accountnumber,float Balance)
            {
                return "Hello" + accountnumber+"Geld"+ Balance;
            }



        }
    }
}
