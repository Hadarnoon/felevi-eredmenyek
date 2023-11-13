using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace feleviproject
{
    class Program
    {

        static double OsztalyAtlag(List<Tanulo> a)
        {
            double osztalyatlag = 0;
            for (int i = 0; i < a.Count; i++)
            {
                osztalyatlag += a[i].TanuloAtlag;
            }
            osztalyatlag /= a.Count;
            return osztalyatlag;
        }

        static List<double> TantargyankentiAtlag(List<Tanulo> a)
        {
            var tantargyakhoz = new List<double>();
            for (int i = 0; i < 8; i++)
            {
                tantargyakhoz.Add(0);
            }
            for (int i = 0; i < a.Count; i++)
            {
                for (int b = 0; b < a[b].Jegyek.Count; b++)
                {
                   tantargyakhoz[b] += a[i].Jegyek[b];
                }
            }
            for (int i = 0; i < tantargyakhoz.Count; i++)
            {
                tantargyakhoz[i] /= 12;
            }
            return tantargyakhoz;
        }

        static List<Tanulo> ProgramozasbolBukottak(List<Tanulo> a)
        {
            var programozasbolBukottak = a.Where(b => b.Jegyek[2] == 1).ToList();
            return programozasbolBukottak;
        }

        static Tanulo ElsoHarmasAngol(List<Tanulo> a)
        {
            var elsoangol = a.Where(b => b.Jegyek[4] == 3).First();
            return elsoangol;
        }

        static int LegjobbJegye(List<Tanulo> a, string tanuloneve)
        {
            var tanulolegjobbja = a.Where(j => j.Nev.ToLower() == tanuloneve).OrderByDescending(o => o.Jegyek);
            return tanulolegjobbja;

        }

        static void Main(string[] args)
        {
            var tanulok = new List<Tanulo>();
            using var sr = new StreamReader(@"..\..\..\src\tanulok.txt");
            _ = sr.ReadLine();

            while (!sr.EndOfStream)
            {
                tanulok.Add(new Tanulo(sr.ReadLine()));
                _ = sr.ReadLine();
            }
            Console.WriteLine("1.feladat: ");
            Console.WriteLine($"Tanulók átlaga:");
            foreach (var item in tanulok)
            {
                Console.WriteLine(item);
            }

            double osztalyatlag = OsztalyAtlag(tanulok);
            Console.WriteLine($"Osztályátlag: {osztalyatlag}");

            
            Console.WriteLine("Tantárgyakkénti átlag: ");
            var tantargyahoz = TantargyankentiAtlag(tanulok);
            foreach (var item in tantargyahoz)
            {
                Console.WriteLine(item);
            }

            var bukottak = ProgramozasbolBukottak(tanulok);
            Console.WriteLine("2.feladat: ");
            foreach (var item in bukottak)
            {
                Console.WriteLine(item);
            }

            var elsoangol = ElsoHarmasAngol(tanulok);
            Console.WriteLine("3.feladat");
            Console.WriteLine(elsoangol);

            Console.WriteLine("4.feladat: ");
            Console.WriteLine("Melyik tanuló legjobb eredményét szeretné megtudni: ");
            var tanuloneve = Console.ReadLine().ToLower();
            var tanulolegjobbja = LegjobbJegye(tanulok, tanuloneve);
            Console.WriteLine($"{tanuloneve} legjobb jegye: {tanulolegjobbja}");

            using var sw = new StreamWriter(@"..\..\..\src\kiiras.txt");
            Console.WriteLine();
            var kiirashoz = tanulok.Where(j => j.Nev.ToLower() == tanuloneve);

        }
    }
}
