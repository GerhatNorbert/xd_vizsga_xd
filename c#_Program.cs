using System.Linq;
using System.IO;

namespace autoapp
{
    public class Auto
    {
        public string Sorszam { get; private set; }
        public string Marka { get; private set; }
        public string Model { get; private set; }
        public int GyartasiEv { get; private set; }
        public string Szin { get; private set; }
        public int EladottDb { get; private set; }
        public int AtlagosEladasiAr { get; private set; }

        public Auto(string sor)
        {
            string[] elemek = sor.Split(';');
            this.Sorszam = elemek[0];
            this.Marka = elemek[1];
            this.Model = elemek[2];
            this.GyartasiEv = int.Parse(elemek[3]);
            this.Szin = elemek[4];
            this.EladottDb = int.Parse(elemek[5]);
            this.AtlagosEladasiAr = int.Parse(elemek[6]);
        }
    }

    internal class Program
    {

        static void Main(string[] args)
        {
            List<Auto> autok = new List<Auto>();
            foreach (string sor in 
                File.ReadAllLines("autok.csv").Skip(1))
            {
                autok.Add(new Auto(sor));
            }

            Feladat5(autok);
            Feladat6(autok);
            Feladat7(autok);
            Feladat8(autok);
        }

        static void Feladat5(List<Auto> adatok)
        {
            Console.WriteLine("\n5. feladat");
            Console.WriteLine($"{adatok.Count} autó található a listában.");
        }

        static void Feladat6(List<Auto> adatok)
        {
            Console.WriteLine("\n6. feladat");
            double atlag = adatok.Average(a => a.EladottDb);

            Console.WriteLine($"{atlag:F1} autó található a listában.");
        }

        static void Feladat7(List<Auto> adatok)
        {
            Console.WriteLine("\n7. feladat");
            Console.WriteLine($"Az elmúlt 5 évben gyártott autók:");

            for (int i = 0; i < adatok.Count; i++)
            {
                if (adatok[i].GyartasiEv >= 2019)
                {
                    Console.WriteLine($"{adatok[i].Marka} {adatok[i].Model} {adatok[i].GyartasiEv}");
                }
            }
        }
        static void Feladat8(List<Auto> adatok)
        {
            Console.WriteLine("\n8. feladat");
            var rendezett = adatok.OrderByDescending(a => a.EladottDb);
            foreach (var auto in rendezett)
            {
                Console.WriteLine($"{auto.Marka}: {auto.EladottDb} darab");
            }


        }
    }
}
