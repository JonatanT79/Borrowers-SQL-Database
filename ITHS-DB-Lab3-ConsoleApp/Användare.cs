using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace ITHS_DB_Lab3_ConsoleApp
{
    class Användare
    {
        public void AnvändarInfo()
        {
            Console.Clear();
            Redigera r = new Redigera();
            VisaAnvändare();
            Console.WriteLine("");
            Console.WriteLine("SKAPA ny användare - Tryck på 'S'");
            Console.WriteLine("RADERA användare - Skriv ID nummer");
            string välj = Console.ReadLine();
            int nr;
            while(!int.TryParse(välj,out nr) && välj.ToUpper() != "S")
            {
                Console.WriteLine("Felaktigt svar");
                välj = Console.ReadLine();
            }

            if (int.TryParse(välj, out nr))
            {
                r.Radera(nr);
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Din ändring är nu genomförd");
                Console.WriteLine("");
                Console.ResetColor();
                VisaAnvändare();
            }
            else if (välj.ToUpper().Equals("S"))
            {
                r.Skapa();
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Ny användare med förnamnet " + r.Förnamn + " skapad");
                Console.WriteLine("");
                Console.ResetColor();
                VisaAnvändare();
            }
        }
        public void VisaAnvändare()
        {
            string connectionstring = "Server=(localdb)\\MSSQLLocalDB;Database=Labb1;Trusted_Connection=True;";
            using (SqlConnection con = new SqlConnection(connectionstring))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Select ID,Förnamn,Efternamn,Ålder FROM användare", con);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"{"ID:", -10}{"Förnamn:", -15}{"Efternamn:", -15}{"Ålder:", -10}");
                    Console.ResetColor();
                    Console.WriteLine($"{rdr.GetInt32(0), -10}{rdr.GetString(1), -15}{rdr.GetString(2), -15}{rdr.GetInt32(3), -10}");
                    LineDivide();
                }
                con.Close();
            }
        }
        public void LineDivide()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
            Console.ResetColor();
        }
    }
}
// fixa cascade delete - om man tar bort en användare som har ett lån --> krash

