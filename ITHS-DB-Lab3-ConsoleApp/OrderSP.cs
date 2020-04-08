using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace ITHS_DB_Lab3_ConsoleApp
{
    class OrderSP
    {
        public int nid { get; set; }
        public int ncID { get; set; }
        public int nLID { get; set; }
        public string neID { get; set; }
        public DateTime LåneDatum { get; set; } = DateTime.Today;
        public string Inlämningsdatum { get; set; }
        public string Borttappad { get; set; } = "NEJ";
        public int SummaAttBetala { get; set; } = 0;
        public int LånadesUtAv { get; set; } = 1;
        public string LämnadesIn { get; set; } = "Lånet Är Aktivt";

        public int mid { get; set; }
        public string meID { get; set; }
        public void VisaLån()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Information om alla lån:");
            Console.WriteLine("");
            Console.ResetColor();
            string connectionstring = "Server = (localdb)\\MSSQLLocalDB; Database = Labb1; Trusted_Connection = True; ";
            using (SqlConnection con = new SqlConnection(connectionstring))
            {
                con.Open();
                // -------------------------------------------------------- Vy ---------------------------------------------------------------
                SqlCommand cmd = new SqlCommand("Select * From LåneInfon", con);
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("KundID:    Förnamn:    Efternamn:    Låneprodukt:   Indificationsvärde: Beskrivning:   Lånedatum:  InlämmningsDatum:  LånadesAv: ");
                    Console.ResetColor();
                    Console.WriteLine(rdr.GetValue(0) + "   " + rdr.GetValue(1) + "     " + rdr.GetValue(2) + "     " + rdr.GetValue(3) + "    " + rdr.GetValue(4) + "       " + rdr.GetValue(5) + "       " + rdr.GetValue(6) + "      " + rdr.GetValue(7) + "      " + rdr.GetValue(8));
                    LineDivide();
                }
                con.Close();
            }
            Console.WriteLine("Tryck på valfri knapp för att återgå till hemsidan");
            Console.ReadKey();
            Console.Clear();
            startmeny.Hemsida();
        }
        public void LånaSP()
        {
            Console.Clear();
            Användare a = new Användare();
            Produkter p = new Produkter();

            string connectionString1 = "Server=(localdb)\\MSSQLLocalDB;Database=Labb1;Trusted_Connection=True;";
            using (SqlConnection con = new SqlConnection(connectionString1))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Select Max(ordersid + 1) from Orders", con);
                SqlDataReader rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    nid = Convert.ToInt32(rdr.GetValue(0));
                }
                con.Close();
            }
            a.VisaAnvändare();
            Console.WriteLine("Skriv in AnvändarensID som ska låna en produkt");
            ncID = Convert.ToInt32(Console.ReadLine());

            Console.Clear();
            p.VisaProdukt();
            Console.WriteLine("Skriv in produktensID som användaren ska låna");
            nLID = Convert.ToInt32(Console.ReadLine());

            Console.Clear();
            string connectionstring2 = "Server = (localdb)\\MSSQLLocalDB; Database = Labb1; Trusted_Connection = True; ";
            using (SqlConnection con2 = new SqlConnection(connectionstring2))
            {
                con2.Open();
                SqlCommand cmd2 = new SqlCommand("Select * from Exemplar where ProduktID = @LID AND Status_Exemplar = 'Tillgänglig' order by ProduktID", con2);
                cmd2.Parameters.AddWithValue("@LID", nLID);
                SqlDataReader rdr2 = cmd2.ExecuteReader();
                while (rdr2.Read())
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("ProduktID:    Indificationsvärde:    Status:");
                    Console.ResetColor();
                    Console.WriteLine(rdr2.GetValue(0) + "             " + rdr2.GetValue(1) + "                 " + rdr2.GetValue(2));
                    LineDivide();
                }
                con2.Close();
            }
            Console.WriteLine("Skriv in exemplarets indifikationsvärdet du vill låna");
            Console.WriteLine("OBS om det inte visas något exemplar betyder det att alla exemplar av den produkten är utlånade");
            Console.WriteLine("OM INGET VISAS - tryck på valfri tangent för att avsluta");
            neID = Console.ReadLine().ToUpper();

            if (neID.Length <= 1)
            {
                Console.WriteLine("Avslutar program");
             // Kasta ett felmeddelande (Exception)
                throw new Exception();
            }
            Console.WriteLine("Skriv in ett inlämmningsdatum för din lånade exemplar: ÅÅÅÅ/MM/DD");
            Inlämningsdatum = Console.ReadLine();
            Console.WriteLine("");

            string connectionstring = "Server = (localdb)\\MSSQLLocalDB; Database = Labb1; Trusted_Connection = True;";
            using (SqlConnection con = new SqlConnection(connectionstring))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(@"Registrera @Id,@CustomerID,@LåneID, @ExemplarID,
                                                @Lånedatum, @InlämmningsDatum, @Borttappad, @SummaAttBetala,
                                                @LånadesUtAv, @LämnadesIn", con);

                cmd.Parameters.AddWithValue("@Id", nid);
                cmd.Parameters.AddWithValue("@CustomerID", ncID);
                cmd.Parameters.AddWithValue("@LåneID", nLID);
                cmd.Parameters.AddWithValue("@ExemplarID", neID);
                cmd.Parameters.AddWithValue("@Lånedatum", LåneDatum);
                cmd.Parameters.AddWithValue("@InlämmningsDatum", Inlämningsdatum);
                cmd.Parameters.AddWithValue("@Borttappad", Borttappad);
                cmd.Parameters.AddWithValue("@SummaAttBetala", SummaAttBetala);
                cmd.Parameters.AddWithValue("@LånadesUtAv", LånadesUtAv);
                cmd.Parameters.AddWithValue("@LämnadesIn", LämnadesIn);

                cmd.ExecuteNonQuery();
                con.Close();
            }
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Lånet är registrerat!");
                Console.ResetColor();
        }
        public void LämnaInSP()
        {
            Console.Clear();
            string connectionstring2 = "Server = (localdb)\\MSSQLLocalDB; Database = Labb1; Trusted_Connection = True; ";
            using (SqlConnection con2 = new SqlConnection(connectionstring2))
            {
                con2.Open();
                SqlCommand cmd2 = new SqlCommand
                (
                    @"select Ordersid,Förnamn,Efternamn, LåneProdukt, Indificationsvärde , Lånedatum,InlämmningsDatum, LämnadesIn, UtlånareFörnamn + ' ' + UtlånareEfternamn  as Utlånare 
                    from orders as o
                    inner join Användare as a on a.id = o.CustomerID 
                    inner join products p on o.låneid = p.id
                    inner join Exemplar as e on e.Indificationsvärde = o.ExemplarID
                    inner join personal pe on pe.ID = o.LånadesUtAv"
                    , con2);
                SqlDataReader rdr = cmd2.ExecuteReader();

                while (rdr.Read())
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("OrderID:    Förnamn:    Efternamn:    Låneprodukt:   Indificationsvärde:");
                    Console.ResetColor();
                    Console.WriteLine(rdr.GetValue(0) + "   " + rdr.GetValue(1) + "     " + rdr.GetValue(2) + "     " + rdr.GetValue(3) + "    " + rdr.GetValue(4));

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("LåneDatum:    Inlämningsdatum:   LämnadesIn:     LånadesAv");
                    Console.ResetColor();
                    Console.WriteLine(rdr.GetValue(5) + "       " + rdr.GetValue(6) + "      " + rdr.GetValue(7) + "      " + rdr.GetValue(8));
                    LineDivide();
                }
                con2.Close();
            }
            Console.WriteLine("Skriv in den OrdersID du vill ska lämna in");
            mid = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Skriv in vad OrdersID hade för indifikationsvärde");
            meID = Console.ReadLine().ToUpper();

            string connectionstring = "Server = (localdb)\\MSSQLLocalDB; Database = Labb1; Trusted_Connection = True; ";
            using (SqlConnection con = new SqlConnection(connectionstring))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("LämnaIn @ID, @ExemplarID", con);
                cmd.Parameters.AddWithValue("@ID", mid);
                cmd.Parameters.AddWithValue("@ExemplarID", meID);

                cmd.ExecuteNonQuery();
                con.Close();
            }
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Lånet är tillbaka lämnat!");
            Console.ResetColor();
        }
        public void LineDivide()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
            Console.ResetColor();
        }
    }
}
