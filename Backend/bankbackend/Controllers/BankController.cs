using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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
        public string Get()
        {
            string query = @"
                select id as ""id"",
                name as ""name"",
                surename as ""surename"",
                email as ""email"",
                telefon as ""telefon"",
                username as ""username""
                From customer";



        DataTable table = new DataTable();
        string ausgabe = string.Empty; ;
            string sqlDatasource = _configuration.GetConnectionString("bankappcon");
            NpgsqlDataReader myReader;
            using (var mycon = new NpgsqlConnection(sqlDatasource))
            {
                mycon.Open();
                using (NpgsqlCommand mycommand = new NpgsqlCommand(query, mycon))
                {
                    myReader = mycommand.ExecuteReader();

                    table.Load(myReader);
                    
                    ausgabe = JsonConvert.SerializeObject(table);
                    
                    myReader.Close();
                    mycon.Close();
                }
            }
            return ausgabe;
        }
    }
}
