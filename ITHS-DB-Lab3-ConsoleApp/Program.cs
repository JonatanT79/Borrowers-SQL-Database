using System;
using System.Data;
using System.Data.SqlClient;

namespace ITHS_DB_Lab3_ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            startmeny.Hemsida();
        }
    }
    static class startmeny
    {
        public static void Hemsida()
        {
            Användare a = new Användare();
            Produkter p = new Produkter();
            Exemplarer e = new Exemplarer();
            OrderSP osp = new OrderSP();
            Console.SetCursorPosition(52, 0);
            Console.WriteLine("--- Hemsida ---");
            Console.WriteLine("Tryck på 1 för att visa info om Användare");
            Console.WriteLine("Tryck på 2 för att visa info om Produkter");
            Console.WriteLine("Tryck på 3 för att visa info om Exemplarer");
            Console.WriteLine("Tryck på 4 för att visa info alla Lån");
            Console.WriteLine("Tryck på 5 för att en användare ska låna ett Exemplar");
            Console.WriteLine("Tryck på 6 för att en användare ska återlämna ett Lån");

            string text = Console.ReadLine();
            int input;

            while (!int.TryParse(text, out input) || input > 6 || input <= 0)
            {
                Console.WriteLine("Felaktigt svar, Skriv med en siffra från 1-6");
                text = Console.ReadLine();
            }

            if (input == 1)
            {
                a.AnvändarInfo();
            }
            else if (input == 2)
            {
                p.ProduktInfo();
            }
            else if (input == 3)
            {
                e.ExemplarInfo();
            }
            else if (input == 4)
            {
                osp.VisaLån();
            }
            else if (input == 5)
            {
                osp.LånaSP();
            }
            else if (input == 6)
            {
                osp.LämnaInSP();
            }
        }
    }
}
