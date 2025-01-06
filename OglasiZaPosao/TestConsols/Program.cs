
using DataAccessLayer;
using Entities;

namespace TestConsols
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Korisnik korisnik = new Korisnik
            {
                NazivKorisnika = "Test",
                EmailKorisnika = "Test@email.com",
                LozinkaKorisnika = "lozinka123",
                TipKorisnika = "Kandidat",
                OpisKorisnika = "Ovo je test korisnik.",
                VestineKorisnika = "C#, SQL",
                DatumRegistracije = DateTime.Now
            };

            IKorisnikRepository korisnikRepository = new KorisnikRepository();
            bool add = korisnikRepository.Add(korisnik);

            Console.WriteLine(add);

        }
    }
}