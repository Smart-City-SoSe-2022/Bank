using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Npgsql;
using System.Data;
namespace bankbackend.Controllers
{
   
        [Route("api/[controller]")]
        [ApiController]
       public class DebitController : Controller
    {

        private readonly IConfiguration _configuration;
        public DebitController(IConfiguration configuration)
        {
            _configuration = configuration;
        }


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

        [Route("Balance/Get/{id}")]
        [HttpGet]
        // GET: api/Debit/Balance/Get/0
        public String Getbalance(int id)
        {
            string query = "SELECT SUM(bankbalance) FROM debit where customerid = 0";
            string ausgabe = string.Empty; ;
            string sqlDatasource = _configuration.GetConnectionString("bankappcon");
            NpgsqlDataReader myReader;
            using (var mycon = new NpgsqlConnection(sqlDatasource))
            {
                mycon.Open();
                using (NpgsqlCommand mycommand = new NpgsqlCommand(query, mycon))
                {
                    myReader = mycommand.ExecuteReader();
                    DataTable table = new DataTable();
                    table.Load(myReader);
                    ausgabe = JsonConvert.SerializeObject(table);
                    myReader.Close();
                    mycon.Close();
                }
            }
            return ausgabe;
        }



        [Route("creat/{id}/{Balance}")]
            [HttpGet]
        // GET: api/Debit/creat/{id}/{Balance}
        public String Post(int id,float Balance)
            {
                string query = "INSERT INTO public.debit(debitid, date, bankbalance, reason, customerid) VALUES(Default ,'"+DateTime.Now+"',"+Balance+", 'cool', "+id+");";
                string sqlDatasource = _configuration.GetConnectionString("bankappcon");
            using var con = new NpgsqlConnection(sqlDatasource);
            con.Open();
            using var cmd = new NpgsqlCommand();
            cmd.Connection = con;
            cmd.CommandText = query;
            cmd.ExecuteNonQuery();

            return "cool";
            }



        }
    
}
