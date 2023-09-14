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
        }
    }
}
