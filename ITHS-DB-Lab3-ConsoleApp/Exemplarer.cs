using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace ITHS_DB_Lab3_ConsoleApp
{
    class Exemplarer
    {
        public void ExemplarInfo()
        {
           
            Console.Clear();
            RedigeraE re = new RedigeraE();
            VisaExemplar();
            Console.WriteLine("");
            Console.WriteLine("SKAPA nytt Exemplar - Tryck på 'S'");
            Console.WriteLine("RADERA Exemplar - Skriv INDIFICATIONSVÄRDE på Exemplaret (Stora & små bokstäver spelar INGEN roll)");
            string välj = Console.ReadLine().ToUpper();

            if (välj.Equals("S"))
            {
                re.SkapaE();
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Nytt Exemplar skapad!");
                Console.WriteLine("");
                VisaExemplar();
                Console.ResetColor();
            }
            else
            {
                re.RaderaE(välj);
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Din ändring är nu genomförd");
                Console.WriteLine("");
                VisaExemplar();
                Console.ResetColor();
            }
        }
        public void VisaExemplar()
        {
            string connectionstring = "Server = (localdb)\\MSSQLLocalDB; Database = Labb1; Trusted_Connection = True; ";
            using (SqlConnection con = new SqlConnection(connectionstring))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Select * from Exemplar order by ProduktID", con);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("ProduktID:    Indificationsvärde:    Status:");
                    Console.ResetColor();
                    Console.WriteLine(rdr.GetValue(0) + "             " + rdr.GetValue(1) + "                 " + rdr.GetValue(2));
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
// skapa columerna över när man hämtar värdet
// lägg till under att man ser tabellen efter ändingen?
// lägg til färg på 2ändring genomförd"osv...??