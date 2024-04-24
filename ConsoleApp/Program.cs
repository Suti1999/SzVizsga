using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ConsoleApp
{
    internal class Program
    {
        //  OSZTÁLYOK    //
        static Adatbazis db = new Adatbazis();

        static List<Dolgozo> dolgozok;

        static void Main(string[] args)
        {
            dolgozok = db.getAllDolgozo();
            feladat01();
            feladat02();
            feladat03();
            feladat04();
            Console.ReadLine();
        }

        //  4. FELADAT - KIÍRJA AZ "ASZTALOSMŰHELY"-BEN A DOLGOZÓK NEVÉT    //
        private static void feladat04()
        {
            Console.WriteLine("4. Feladat:");
            Console.WriteLine("\t Asztalosműhelyben dolgozok nevei:");
            foreach (var item in dolgozok.FindAll(a => a.reszleg == "asztalosműhely"))
            {
                Console.WriteLine($"\t {item.nev}. ");
            }
        }

        //  3. FELADAT - HÁNYAN DOLGOZNAK AZ EGYES RÉSZLEGEKEN   //
        private static void feladat03()
        {
            Console.WriteLine("3. Feladat:");
            foreach (var item in dolgozok.GroupBy(a => a.reszleg).Select(b => new { reszleg = b.Key, letszam = b.Count() }).OrderBy(c => c.reszleg))
            {
                Console.WriteLine($"\t {item.reszleg}: {item.letszam} fő.");
            }
        }

        //  2. FELADAT - A LEGMAGASABB KERESETŰ DOLGOZÓ NEVÉT ÍRJA KI   //
        private static void feladat02()
        {
            int maxBer = dolgozok.Max(a => a.ber);
            Dolgozo dolgozo=dolgozok.Find(a => a.ber == maxBer);
            Console.WriteLine("2. Feladat:");
            Console.WriteLine($"\t A legmagasabb keresetű dolgozó neve: {dolgozo.nev}.");
        }

        //  1. FELADAT - AZ ÖSSZES DOLGOZÓ ÉRTÉKÉT ÍRJA KI  //
        private static void feladat01()
        {
            Console.WriteLine("1. Feladat:");
            Console.WriteLine($"\t A dolgozók száma: {dolgozok.Count} fő.");
        }
    }
}
