using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace ITHS_DB_Lab3_ConsoleApp
{
    class Produkter
    {
        public void ProduktInfo()
        {
            Console.Clear();
            RedigeraP rp = new RedigeraP();
            VisaProdukt();
            Console.WriteLine("");
            Console.WriteLine("SKAPA ny Produkt - Tryck på 'S'");
            Console.WriteLine("RADERA Produkt - Skriv ID nummer");
            string välj = Console.ReadLine();
            int nr;
            while (!int.TryParse(välj, out nr) && välj.ToUpper() != "S")
            {
                Console.WriteLine("Felaktigt svar");
                välj = Console.ReadLine();
            }

            if (int.TryParse(välj, out nr))
            {
                rp.RaderaP(nr);
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Din ändring är nu genomförd");
                Console.WriteLine("");
                VisaProdukt();
                Console.ResetColor();
            }
            else if (välj.ToUpper().Equals("S"))
            {
                rp.SkapaP();
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Ny Produkt '" + rp.LåneProdukt + "' är skapad");
                Console.WriteLine("");
                VisaProdukt();
                Console.ResetColor();
            }
        }
        public void VisaProdukt()
        {
            string connectionstring = "Server = (localdb)\\MSSQLLocalDB; Database = Labb1; Trusted_Connection = True; ";
            using (SqlConnection con = new SqlConnection(connectionstring))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Select Id,Låneprodukt,Beskrivning,Kategori,Pris from Products", con);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("ID:    Låneprodukt:      Beskrivning:           Kategori:      Pris:");
                    Console.ResetColor();
                    Console.WriteLine(rdr.GetValue(0) + "      " + rdr.GetValue(1) + "          " + rdr.GetValue(2) + "          " + rdr.GetValue(3) + "      " + rdr.GetValue(4));
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
