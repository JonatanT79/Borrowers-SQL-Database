using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ITHS_DB_Lab3_Web
{
    public class AnvändareModel : PageModel
    {
       
        public List<Användare> lista = new List<Användare>();

        public void OnGet()
        {
            string connectionString = "Server=(localdb)\\MSSQLLocalDB;Database=Labb1;Trusted_Connection=True;";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("SELECT ID, Förnamn, Efternamn, Ålder FROM användare", con);
                cmd.CommandType = CommandType.Text;

                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Användare anv = new Användare();

                    anv.Id = Convert.ToInt32(rdr["Id"]);
                    anv.Name = rdr["Förnamn"].ToString();
                    anv.Lastname = rdr["Efternamn"].ToString();
                    anv.Ålder = Convert.ToInt32(rdr["Ålder"]);

                    lista.Add(anv);
                }
                con.Close();
            }
        }
    }
}
