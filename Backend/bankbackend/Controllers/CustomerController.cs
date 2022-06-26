using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Npgsql;
using System.Data;
namespace bankbackend.Controllers
{

    
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : Controller
    {
        private readonly IConfiguration _configuration;
        public CustomerController(IConfiguration configuration)
        {
            _configuration = configuration;
        }




        // GET: api/Customer
        [HttpGet]
        public string Get()
        {
            string query = "SELECT * FROM customer";
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
    


    [Route("Get/{id}")]
        [HttpGet]
        // GET: api/Customer/Get/{id}
        public string Get(int Id)
        {
            string query = "SELECT * FROM customer WHERE id ="+Id;
            string ausgabe = string.Empty; ;
            string sqlDatasource = _configuration.GetConnectionString("bankappcon");
            string[] ausgabeauswerten;
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


        [Route("creat/{id}")]
        [HttpGet]
        // GET: api/Debit/creat/{id}
        public String Post(int id)
        {
            try
            {
                string query = "INSERT INTO public.customer(id, username, name, surename, email, telefon) VALUES (" + id + ", 'null', 'null', 'null', 'null', 'null');";
                string sqlDatasource = _configuration.GetConnectionString("bankappcon");
                using var con = new NpgsqlConnection(sqlDatasource);
                con.Open();
                using var cmd = new NpgsqlCommand();
                cmd.Connection = con;
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();

                return "kunde erstellt";
            }
            catch (Exception e)
            {
                return "kunde nicht erstellt";
            }
        }


    }
}
