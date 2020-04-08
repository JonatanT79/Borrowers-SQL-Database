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
    public class RedigeraModel : PageModel
    {
        [BindProperty]
        public Användare Redigera { get; set; }

        public void OnGet(int? RedigeraId)
        {
            if (RedigeraId != null)
            {
                string connectionString = "Server=(localdb)\\MSSQLLocalDB;Database=Labb1;Trusted_Connection=True;";
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();

                    SqlCommand cmd = new SqlCommand("SELECT Id, Förnamn, Efternamn, Ålder FROM Användare WHERE Id = @RedigeraId", con);
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.AddWithValue("@RedigeraId", RedigeraId);

                    Redigera  = new Användare ();

                    SqlDataReader rdr = cmd.ExecuteReader();
                    rdr.Read();

                    Redigera.Id = Convert.ToInt32(rdr["Id"]);
                    Redigera.Name = rdr["Förnamn"].ToString();
                    Redigera.Lastname = rdr["Efternamn"].ToString();
                    Redigera.Ålder = Convert.ToInt32(rdr["Ålder"]);

                    con.Close();
                }
            }
        }
        public IActionResult OnPost()
        {
            string connectionString = "Server=(localdb)\\MSSQLLocalDB;Database=Labb1;Trusted_Connection=True;";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string sql;
                if (Redigera.Id == null)
                {
                    sql = @"INSERT INTO Användare (Id,Förnamn, Efternamn, Ålder)
                            VALUES
                            (@ID, @Name, @Lastname, @Ålder)";
                }
                else
                {
                    sql = @"UPDATE Användare
                            SET Id = @Id, Förnamn = @Name, Efternamn = @Lastname,  Ålder = @Ålder
                            WHERE Id = @Id";
                }
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.CommandType = CommandType.Text;

                if (Redigera.Id != null)
                {
                    cmd.Parameters.AddWithValue("@Id", Redigera.Id);
                }
                cmd.Parameters.AddWithValue("@Name", Redigera.Name);
                cmd.Parameters.AddWithValue("@Lastname", Redigera.Lastname);
                cmd.Parameters.AddWithValue("@Ålder", Redigera.Ålder);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            return RedirectToPage("./Användare");
        }
    }
}
