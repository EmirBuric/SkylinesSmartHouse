using SkylinesSmartHouseConsoleApp.Controller;
using SkylinesSmartHouseConsoleApp.Modeli;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkylinesSmartHouseConsoleApp.Meniji
{
    public class GlavniMeni
    {
        private readonly KorisnikController _korisnik;
        private readonly KucaController _kuca;
        private readonly SobaController _soba;
        private readonly SenzorController _senzor;
        private readonly UredajController _uredaj;

        public GlavniMeni(KorisnikController korisnik,
            KucaController kuca,
            UredajController uredaj,
            SobaController soba,
            SenzorController senzor)
        {
            _korisnik = korisnik;
            _kuca = kuca;
            _uredaj = uredaj;
            _soba = soba;
            _senzor = senzor;
        }

        public void Prikazi()
        {
            Console.WriteLine("Dobro dosli u SmartHome");
            Console.WriteLine("Registrujte Vaš račun");

            _korisnik.Dodaj();


            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("Odaberite opciju");
                Console.WriteLine("1. Korisnik");
                Console.WriteLine("2. Kuca");
                Console.WriteLine("3. Soba");
                Console.WriteLine("4. Senzor");
                Console.WriteLine("5. Uredjaj");
                Console.WriteLine("6. Izlaz");
                string opcija = Console.ReadLine();

                switch (opcija)
                {
                    case "1":
                        var korisnikMenu = new KorisnikMenu(_korisnik);
                        korisnikMenu.PrikaziMeni();
                        break;
                    case "2":
                        var kucaMenu = new KucaMenu(_kuca);
                        kucaMenu.PrikaziMeni();
                        break;
                    case "3":
                        var sobaMenu = new SobaMenu(_soba);
                        sobaMenu.PrikaziMeni();
                        break;
                    case "4":
                        var senzorMenu = new SenzorMenu(_senzor);
                        senzorMenu.PrikaziMeni();
                        break;
                    case "5":
                        var uredjajMenu = new UredajMenu(_uredaj);
                        uredjajMenu.PrikaziMeni();
                        break;
                    case "6":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Pogresan unos");
                        break;
                }
            }
        }
    }
}
