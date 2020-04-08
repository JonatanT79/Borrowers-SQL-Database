using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace ITHS_DB_Lab3_ConsoleApp
{
    class Redigera
    {
        public int ID { get; set; }
        public string Förnamn { get; set; }
        public string Efternamn { get; set; }
        public int Ålder;
        public int Roll { get; set; } = 4;
        public int Idnr { get; set; }

        public void Radera(int IDnum)
        {
            string connectionString = "Server=(localdb)\\MSSQLLocalDB;Database=Labb1;Trusted_Connection=True;";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("DELETE användare WHERE Id = @Id", con);
                cmd.Parameters.AddWithValue("@Id", IDnum);
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        public void Skapa()
        {
            string connectionString1 = "Server=(localdb)\\MSSQLLocalDB;Database=Labb1;Trusted_Connection=True;";
            using (SqlConnection con = new SqlConnection(connectionString1))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Select Max(id + 1) from användare", con);
                SqlDataReader rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    Idnr = Convert.ToInt32(rdr.GetValue(0));
                }
                con.Close();
            }
            ID = Idnr;
            Console.Write("Skriv in Förnamn: ");
            Förnamn = Console.ReadLine();

            Console.Write("Skriv in Efternamn: ");
            Efternamn = Console.ReadLine();

            Console.Write("Skriv in Ålder: ");

            while (!int.TryParse(Console.ReadLine(),out Ålder))
            {
                Console.WriteLine("Felaktigt svar, skriv med siffror");
            }

            string connectionString = "Server=(localdb)\\MSSQLLocalDB;Database=Labb1;Trusted_Connection=True;";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string sql = @"INSERT INTO användare(ID,Förnamn,Efternamn,Ålder,RollID)
                             VALUES(@ID, @Name, @Lastname, @Age, @Role)";

                SqlCommand cmd = new SqlCommand(sql, con);

                cmd.Parameters.AddWithValue("@ID", ID);
                cmd.Parameters.AddWithValue("@Name", Förnamn);
                cmd.Parameters.AddWithValue("@Lastname", Efternamn);
                cmd.Parameters.AddWithValue("@Age", Ålder);
                cmd.Parameters.AddWithValue("@Role", Roll);

                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
    }

    // -----------------------------------------------------------------------------------------------------------------------------------------------------
    class RedigeraP
    {

        public int ID { get; set; }
        public string LåneProdukt { get; set; }
        public string Beskrivning { get; set; }
        public string Kategori { get; set; }
        public int Pris;

        public int Idnr { get; set; }
        public void RaderaP(int IDnum)
        {
            string connectionString = "Server=(localdb)\\MSSQLLocalDB;Database=Labb1;Trusted_Connection=True;";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("DELETE products WHERE Id = @Id", con);
                cmd.Parameters.AddWithValue("@Id", IDnum);
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        public void SkapaP()
        {
            string connectionString1 = "Server=(localdb)\\MSSQLLocalDB;Database=Labb1;Trusted_Connection=True;";
            using (SqlConnection con = new SqlConnection(connectionString1))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Select Max(id + 1) from Products", con);
                SqlDataReader rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    Idnr = Convert.ToInt32(rdr.GetValue(0));
                }
                con.Close();
            }
            ID = Idnr;
            Console.Write("Skriv in produktens Namn: ");
            LåneProdukt = Console.ReadLine();

            Console.Write("Skriv en kort beskrivning på produkten: ");
            Beskrivning = Console.ReadLine();

            Console.Write("Skriv en kategori för produkten ");
            Kategori = Console.ReadLine();

            Console.Write("Lånepris: ");

            while (!int.TryParse(Console.ReadLine(), out Pris))
            {
                Console.WriteLine("Felaktigt svar, skriv med siffror");
            }

            string connectionString = "Server=(localdb)\\MSSQLLocalDB;Database=Labb1;Trusted_Connection=True;";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string sql = @"INSERT INTO Products
                             VALUES(@ID, @LåneProdukt,@Beskrivning,@Kategori,@Pris)";

                SqlCommand cmd = new SqlCommand(sql, con);

                cmd.Parameters.AddWithValue("@ID", ID); // högrer är värdet, vänster är parametern
                cmd.Parameters.AddWithValue("@LåneProdukt", LåneProdukt);
                cmd.Parameters.AddWithValue("@Beskrivning", Beskrivning);
                cmd.Parameters.AddWithValue("@Kategori", Kategori);
                cmd.Parameters.AddWithValue("@Pris", Pris);

                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
    }
    // -----------------------------------------------------------------------------------------------------------------------------------------------------
    class RedigeraE
    {
        public int ID;
        public string Speciell { get; set; }
        public string Status { get; set; } = "Tillgänglig";

        public void RaderaE(string identitet)
        {
            string connectionString = "Server=(localdb)\\MSSQLLocalDB;Database=Labb1;Trusted_Connection=True;";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Delete Exemplar where indificationsvärde = @Iden", con);
                cmd.Parameters.AddWithValue("@Iden", identitet);
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        public void SkapaE()
        {
            // visa alla produkter
            Console.Clear();
            string constring = "Server=(localdb)\\MSSQLLocalDB;Database=Labb1;Trusted_Connection=True;";
            using (SqlConnection con = new SqlConnection(constring))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Select ID, LåneProdukt From Products Order by ID",con);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("ID:     Produkt:");
                    Console.ResetColor();
                    Console.WriteLine(rdr.GetValue(0) + "       " + rdr.GetValue(1));
                }
                con.Close();
            }
            Console.WriteLine("");
            Console.Write("Skriv in produktens ID du vill skapa ett exemplar för: ");

            while (!int.TryParse(Console.ReadLine(), out ID))
            {
                Console.WriteLine("Felaktigt svar, skriv med siffra/siffror");
            }

            Console.WriteLine("Skriv in ett Indificationsvärde för exemplaret: (Stora & små bokstäver spelar INGEN roll)");
            Speciell = Console.ReadLine().ToUpper();
            
                string connectionString1 = "Server=(localdb)\\MSSQLLocalDB;Database=Labb1;Trusted_Connection=True;";
                using (SqlConnection con = new SqlConnection(connectionString1))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("Insert into Exemplar(ProduktID, Indificationsvärde ,Status_Exemplar) values(@ID, @Serienummer,@Status)", con);
                    cmd.Parameters.AddWithValue("@ID", ID);
                    cmd.Parameters.AddWithValue("@Serienummer", Speciell);
                    cmd.Parameters.AddWithValue("@Status", Status);

                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            
        }
    }
}

// skapa felhantering ifall man inte skriver in något/fel data när man skapar saker