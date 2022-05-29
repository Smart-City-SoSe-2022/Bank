using Microsoft.AspNetCore.Mvc;
using Npgsql;
using System.Data;


namespace bankbackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BankController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public BankController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

     

      
        // GET: api/Values
            [HttpGet]
        public JsonResult Get()
        {

        

        string query = @"
                select Id as ""Id"",
                name as ""name"",
                surename as ""surename"",
                email as ""email"",
                telefon as ""telefon"",
                username as ""username""
                From Costumer";


            DataTable table = new DataTable();

            string sqlDatasource = _configuration.GetConnectionString("bankappcon");
            NpgsqlDataReader myReader;

            

            using (var mycon = new NpgsqlConnection(sqlDatasource))
            {
                mycon.Open();
                using (NpgsqlCommand mycommand = new NpgsqlCommand(query, mycon))
                {
                    myReader = mycommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    mycon.Close();
                }
            }

            
            return new JsonResult(table);
        }
    }
}
