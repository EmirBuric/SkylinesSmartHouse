using SkylinesSmartHouseConsoleApp.Azuriraj;
using SkylinesSmartHouseConsoleApp.Dodaj;
using SkylinesSmartHouseConsoleApp.Modeli;
using SkylinesSmartHouseConsoleApp.Pretrazi;
using SkylinesSmartHouseConsoleApp.Servisi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkylinesSmartHouseConsoleApp.Controller
{
    public class KorisnikController
    {
        private readonly IKorisnikService _service;

        public KorisnikController(IKorisnikService service)
        {
            _service = service;
        }

        public void Dodaj()
        {
            var dodaj = new KorisnikDodaj();

            Console.WriteLine("Zdravo, unesite Vaše ime:");
            dodaj.Naziv = Console.ReadLine();
            while (string.IsNullOrEmpty(dodaj.Naziv))
            {
                Console.WriteLine("Molimo Vas da unesete ime");
                dodaj.Naziv = Console.ReadLine();
            }

            Console.WriteLine("Unesite Vaše prezime:");
            dodaj.Prezime = Console.ReadLine();
            while (string.IsNullOrEmpty(dodaj.Prezime))
            {
                Console.WriteLine("Molimo Vas da unesete prezime");
                dodaj.Prezime = Console.ReadLine();
            }
            Console.WriteLine("Unesite Vas Mail:");
            dodaj.Email = Console.ReadLine();
            while (string.IsNullOrEmpty(dodaj.Email))
            {
                Console.WriteLine("Molimo Vas da unesete ime");
                dodaj.Email = Console.ReadLine();
            }
            Console.WriteLine("Unesite Vasu sifru");
            dodaj.Sifra = Console.ReadLine();
            while (string.IsNullOrEmpty(dodaj.Sifra))
            {
                Console.WriteLine("Molimo Vas da unesete ime");
                dodaj.Sifra = Console.ReadLine();
            }

            _service.Insert(dodaj);
            Console.WriteLine("Uspjesno ste se registrovali");
        }

        public void Info()
        {
            var kor = _service.GetById(1);
            Console.WriteLine("Vasi podaci");

            Console.WriteLine($"Korisnik:{kor.Ime} {kor.Prezime}, mail: {kor.Email}");
           
        }

        public void Azuriraj()
        {
            var update = new KorisnikAzuriraj();

            Console.WriteLine("Azuriranje korisnika");
            

            Console.WriteLine("Unesite novo ime: ");
            update.Naziv = Console.ReadLine();
            while (string.IsNullOrEmpty(update.Naziv))
            {
                Console.WriteLine("Molimo Vas da unesete ime");
                update.Naziv = Console.ReadLine();
            }

            Console.WriteLine("Unesite novo prezime: ");
            update.Prezime = Console.ReadLine();
            while (string.IsNullOrEmpty(update.Prezime))
            {
                Console.WriteLine("Molimo Vas da unesete prezime");
                update.Prezime = Console.ReadLine();
            }

            Console.WriteLine("Unesite novi Mail: ");
            update.Email = Console.ReadLine();
            while (string.IsNullOrEmpty(update.Email))
            {
                Console.WriteLine("Molimo Vas da unesete mail");
                update.Email = Console.ReadLine();
            }

            Console.WriteLine("Unesite novu sifru: ");
            update.Sifra = Console.ReadLine();
            while (string.IsNullOrEmpty(update.Sifra))
            {
                Console.WriteLine("Molimo Vas da unesete sifru");
                update.Naziv = Console.ReadLine();
            }


            _service.Update(1, update);
            Console.WriteLine("Azurirali ste svoj profil");
        }


    }
}
