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
    public class UredajController
    {
        private readonly IUredajService _service;

        public UredajController(IUredajService service)
        {
            _service = service;
        }

        public void Dodaj()
        {
            var dodaj = new UredajDodaj();

            Console.WriteLine("Zdravo, unesite naziv uredjaja:");
            dodaj.Naziv = Console.ReadLine();
            while (string.IsNullOrEmpty(dodaj.Naziv))
            {
                Console.WriteLine("Molimo Vas da unesete naziv");
                dodaj.Naziv = Console.ReadLine();
            }
            Console.WriteLine("Unesite proizvodjaca uredjaja:");
            dodaj.Proizvodjac = Console.ReadLine();
            while (string.IsNullOrEmpty(dodaj.Proizvodjac))
            {
                Console.WriteLine("Molimo Vas da unesete proizvodjaca");
                dodaj.Proizvodjac = Console.ReadLine();
            }

            Console.WriteLine("Unesite model uredjaja:");
            dodaj.Model = Console.ReadLine();
            while (string.IsNullOrEmpty(dodaj.Model))
            {
                Console.WriteLine("Molimo Vas da unesete model");
                dodaj.Model = Console.ReadLine();
            }

            Console.WriteLine("Unesite Id sobe kojoj uredjaj pripada, ukoliko imate samo jednu sobu unesite 1");
            string unosId = Console.ReadLine();
            int id;
            while (!Int32.TryParse(unosId, out id))
            {
                Console.WriteLine("Molimo Vas da unesete id");
                unosId = Console.ReadLine();
            }
            dodaj.SobaId = id;
            Console.WriteLine("Unesite Id senzora s kojim zelite spojiti uredjaj, ukoliko imate samo jedan senzor unesite 1");
            string unosSenId = Console.ReadLine();
            int Senid;
            while (!Int32.TryParse(unosSenId, out Senid))
            {
                Console.WriteLine("Molimo Vas da unesete id");
                unosSenId = Console.ReadLine();
            }
            dodaj.SenzorId = Senid;

            _service.Insert(dodaj);
            Console.WriteLine("Uredjaj dodan");
        }

        public void Pretraga()
        {
            var pretraga = new UredajPretraga();
            Console.WriteLine("Pretrazite Uredjaj");
            pretraga.Naziv = Console.ReadLine();
            while (string.IsNullOrEmpty(pretraga.Naziv))
            {
                Console.WriteLine("Molimo Vas da unesete naziv");
                pretraga.Naziv = Console.ReadLine();
            }


            var uredjaji = _service.GetSearchRes(pretraga);

            foreach (Uredaj uredjaj in uredjaji)
            {
                Console.WriteLine($"Uredjaj,GetSearch: {uredjaj.Naziv}," +
                    $" proizvodjac:{uredjaj.Proizvodjac}," +
                    $"model:{uredjaj.Model}, " +
                    $"ukljucen:{uredjaj.Ukljucen}," +
                    $" Id:{uredjaj.Id}, "+
                    $"SobaId: {uredjaj.SobaId}, "+
                    $"SenzorId: {uredjaj.SenzorId}"
                    );
            }
            Console.WriteLine("Pretraga zavrsena");
        }

        public void Azuriraj()
        {
            var update = new UredajAzuriraj();

            Console.WriteLine("Azuriranje uredjaja");
            Console.WriteLine("Unesite Id uredjaja koji zelite azurirat");
            string unos = Console.ReadLine();
            int Id;
            while (!Int32.TryParse(unos, out Id))
            {
                Console.WriteLine("Molimo Vas da unesete Id");
                unos = Console.ReadLine();
            }

            Console.WriteLine("Unesite novi naziv uredjaja: ");
            update.Naziv = Console.ReadLine();
            while (string.IsNullOrEmpty(update.Naziv))
            {
                Console.WriteLine("Molimo Vas da unesete naziv");
                update.Naziv = Console.ReadLine();
            }
            Console.WriteLine("Unesite novog proizvodjaca uredjaja: ");
            update.Proizvodjac = Console.ReadLine();
            while (string.IsNullOrEmpty(update.Proizvodjac))
            {
                Console.WriteLine("Molimo Vas da unesete naziv");
                update.Proizvodjac = Console.ReadLine();
            }
            Console.WriteLine("Unesite novi model uredjaja: ");
            update.Model = Console.ReadLine();
            while (string.IsNullOrEmpty(update.Model))
            {
                Console.WriteLine("Molimo Vas da unesete naziv");
                update.Model = Console.ReadLine();
            }


            _service.Update(Id, update);
            Console.WriteLine("Uredjaj je azuriran");
        }

        public void UkljuciUredjaj()
        {
            Console.WriteLine("Unesite Id uredjaja koji zelite ukljuciti/iskljuciti");
            string unos = Console.ReadLine();
            int Id;
            while (!Int32.TryParse(unos, out Id))
            {
                Console.WriteLine("Molimo Vas da unesete Id");
                unos = Console.ReadLine();
            }
            bool stanje = _service.UpaliUgasi(Id);
            if (stanje) 
            {
                Console.WriteLine("Uredjaj ukljucen");
            }
            else
            {
                Console.WriteLine("Uredjaj iskljucen");
            }
            
        }
    }
}
