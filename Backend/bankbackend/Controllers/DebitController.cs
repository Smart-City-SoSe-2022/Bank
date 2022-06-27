using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Npgsql;
using System.Data;
using System.Text.Json;
using static bankbackend.JWTdecode;


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
        
        
        [Route("Get")]
        [HttpGet]
        // GET: api/Debit/Get
        public String Getdebit()
        {
            string cookieValueFromReq = Request.Cookies["JWT"];
            Console.WriteLine(cookieValueFromReq);
            string a = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIwIiwibmFtZSI6IkpvaG4gRG9lIiwiaWF0IjoxOTE2MjM5MDIyfQ.MTek18-U2FKiOJvH89WskFJ9W-Yj8dK4zPgfkA-di2Q";
            string b = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIxIiwibmFtZSI6IkpvaG4gRG9lIiwiaWF0IjoxOTk2MjM5MDIyfQ.Aqbekm4AhhNLhZC3eUwcZFOhFK_dX9l-ehYXZf3xcpI";
            JWTdecode jwtDecode = new JWTdecode();
            int id = jwtDecode.GetID(a);

            string query = "SELECT * FROM debit where customerid = " + id;
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
        
        [Route("Balance/Get")]
        [HttpGet]
        // GET: api/Debit/Balance/Get
        public String Getbalance()
        {
            string cookieValueFromReq = Request.Cookies["JWT"];
            Console.WriteLine(cookieValueFromReq);
            string a = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIwIiwibmFtZSI6IkpvaG4gRG9lIiwiaWF0IjoxOTE2MjM5MDIyfQ.MTek18-U2FKiOJvH89WskFJ9W-Yj8dK4zPgfkA-di2Q";
            string b = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIxIiwibmFtZSI6IkpvaG4gRG9lIiwiaWF0IjoxOTk2MjM5MDIyfQ.Aqbekm4AhhNLhZC3eUwcZFOhFK_dX9l-ehYXZf3xcpI";
            JWTdecode jwtDecode = new JWTdecode();
            int id = jwtDecode.GetID(a);
           
            try
            {
                string query = "SELECT SUM(bankbalance) FROM debit where customerid = " + id;
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
            catch (Exception ex)
            {
                return "sum:fehler";
            }
        }


        [Route("creat/einzahlung")]
        [HttpPost]
        // GET: api/Debit/creat/einzahlung
        public string createinzahlung([FromBody] JsonElement body)
        {

            string cookieValueFromReq = Request.Cookies["JWT"];
            Console.WriteLine(cookieValueFromReq);
            string a = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIwIiwibmFtZSI6IkpvaG4gRG9lIiwiaWF0IjoxOTE2MjM5MDIyfQ.MTek18-U2FKiOJvH89WskFJ9W-Yj8dK4zPgfkA-di2Q";
            string b = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIxIiwibmFtZSI6IkpvaG4gRG9lIiwiaWF0IjoxOTk2MjM5MDIyfQ.Aqbekm4AhhNLhZC3eUwcZFOhFK_dX9l-ehYXZf3xcpI";
            JWTdecode jwtDecode = new JWTdecode();
            int idsend = jwtDecode.GetID(a);
            try
            {
                float balance = float.Parse(body.GetProperty("betrag").ToString());
                float balancesend = balance * (-1);
                int id = int.Parse(body.GetProperty("kontonr").ToString());
                string reason = body.GetProperty("reason").ToString();
                string query = "INSERT INTO public.debit(debitid, date, bankbalance, reason, customerid, fromuser) VALUES(Default,'" + DateTime.Now + "'," + balance + ", 'Einzahlung', " + id + ", " + 99999 + ");";
                string sqlDatasource = _configuration.GetConnectionString("bankappcon");
                using var con = new NpgsqlConnection(sqlDatasource);
                con.Open();
                using var cmd = new NpgsqlCommand();
                cmd.Connection = con;
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();
                return "funtkioniert";
            }
            catch (Exception ex)
            {
                return "fehler";
            }
        }

            [Route("creat")]
        [HttpPost]
        // GET: api/Debit/creat
        public string creatdebiIndex([FromBody] JsonElement body)
        {

            string cookieValueFromReq = Request.Cookies["JWT"];
            Console.WriteLine(cookieValueFromReq);
            string a = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIwIiwibmFtZSI6IkpvaG4gRG9lIiwiaWF0IjoxOTE2MjM5MDIyfQ.MTek18-U2FKiOJvH89WskFJ9W-Yj8dK4zPgfkA-di2Q";
                string b = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIxIiwibmFtZSI6IkpvaG4gRG9lIiwiaWF0IjoxOTk2MjM5MDIyfQ.Aqbekm4AhhNLhZC3eUwcZFOhFK_dX9l-ehYXZf3xcpI";
            JWTdecode jwtDecode = new JWTdecode();
            int idsend = jwtDecode.GetID(a);
            try
            {
                float balance = float.Parse(body.GetProperty("betrag").ToString());
                float balancesend = balance * (-1);
                int id = int.Parse(body.GetProperty("kontonr").ToString());
                string reason = body.GetProperty("reason").ToString();
                string query = "INSERT INTO public.debit(debitid, date, bankbalance, reason, customerid, fromuser) VALUES(Default,'" + DateTime.Now + "'," + balance + ", '" + reason + "', " + id + ", " + idsend + ");INSERT INTO public.debit(debitid, date, bankbalance, reason, customerid, fromuser) VALUES(Default,'" + DateTime.Now + "'," + balancesend + ", '" + reason + "', " + idsend + ", " + id + ");";
                string sqlDatasource = _configuration.GetConnectionString("bankappcon");
                using var con = new NpgsqlConnection(sqlDatasource);
                con.Open();
                using var cmd = new NpgsqlCommand();
                cmd.Connection = con;
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();
                return "funtkioniert";
            }
            catch (Exception ex)
            {
                return "fehler";
            }

        }


        }
    
}
