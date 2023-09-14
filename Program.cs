using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CA230911
{
    class Program
    {
        static void Main(string[] args)
        {
            var versenyzok = new List<Versenyzo>();
            var sr = new StreamReader(@"..\..\..\src\fob2016.txt",
                Encoding.UTF8);
            while (!sr.EndOfStream)
                versenyzok.Add(new Versenyzo(sr.ReadLine()));
            Console.WriteLine($"3. feladat: Versenyzők száma: {versenyzok.Count}");

            int f4 = versenyzok.Count(v => !v.Kategoria);

            Console.WriteLine($"4. feladat: Női versenyzők aránya: " +
                $"{f4/(float)versenyzok.Count*100:0.00}%");

            var noiBajnok = versenyzok
                .Where(v => !v.Kategoria)
                .OrderBy(v => v.Osszpontszam)
                .Last();

            Console.WriteLine($"6. feladat: A bajnok női versenyző");
            Console.WriteLine($"\tNév: {noiBajnok.Nev}");
            Console.WriteLine($"\tEgyesület: {noiBajnok.Egyesulet}");
            Console.WriteLine($"\tÖsszpont: {noiBajnok.Osszpontszam}");

            using var sw = new StreamWriter(
                path: @"..\..\..\src\osszpontFF.txt",
                append: false,
                encoding: Encoding.UTF8);

            foreach (var v in versenyzok)
                if (v.Kategoria) sw.WriteLine($"{v.Nev};{v.Osszpontszam}");

            var egys = versenyzok
                .GroupBy(v => v.Egyesulet)
                .Where(g => g.Key is not null && g.Count() > 2);

            Console.WriteLine("8. feladat: Egyesület statisztika");

            foreach (var e in egys)
            {
                Console.WriteLine($"\t{e.Key} - {e.Count()} fő");
            }
            
        }
    }
}
