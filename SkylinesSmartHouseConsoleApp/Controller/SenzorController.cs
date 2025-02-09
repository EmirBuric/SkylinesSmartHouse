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
    public class SenzorController
    {
        private readonly ISenzorService _service;

        public SenzorController(ISenzorService service)
        {
            _service = service;
        }

        public void Dodaj()
        {
            var dodaj = new SenzorDodaj();

            Console.WriteLine("Zdravo, unesite naziv senzora:");
            dodaj.Naziv = Console.ReadLine();
            while (string.IsNullOrEmpty(dodaj.Naziv))
            {
                Console.WriteLine("Molimo Vas da unesete naziv");
                dodaj.Naziv = Console.ReadLine();
            }

            _service.Insert(dodaj);
            Console.WriteLine("Senzor dodan");
        }

        public void Pretraga()
        {
            var pretraga = new SenzorPretraga();
            Console.WriteLine("Pretrazite senzore po nazivu");
            pretraga.Naziv = Console.ReadLine();
            while (string.IsNullOrEmpty(pretraga.Naziv))
            {
                Console.WriteLine("Molimo Vas da unesete naziv");
                pretraga.Naziv = Console.ReadLine();
            }


            var senzori = _service.GetSearchRes(pretraga);

            foreach (Senzor senzor in senzori)
            {
                Console.WriteLine($"Senzor,GetSearch: {senzor.Naziv}, ID: {senzor.Id}");
            }
            Console.WriteLine("Pretraga zavrsena");

            
        }
        public void Azuriraj()
        {
            var update = new SenzorAzuriraj();

            Console.WriteLine("Azuriranje senzora");
            Console.WriteLine("Unesite Id senzora koji zelite azurirat");
            string unos = Console.ReadLine();
            int Id;
            while (!Int32.TryParse(unos, out Id))
            {
                Console.WriteLine("Molimo Vas da unesete Id");
                unos = Console.ReadLine();
            }

            Console.WriteLine("Unesite novi naziv senzora: ");
            update.Naziv = Console.ReadLine();
            while (string.IsNullOrEmpty(update.Naziv))
            {
                Console.WriteLine("Molimo Vas da unesete naziv");
                update.Naziv = Console.ReadLine();
            }

            _service.Update(Id, update);
            Console.WriteLine("Senzor je azuriran");
        }


        public void UkljuciSenzor()
        {
            Console.WriteLine("Unesite Id senzora koji zelite ukljuciti/iskljuciti");
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
                Console.WriteLine("Senzor ukljucen");
            }
            else
            {
                Console.WriteLine("Senzor iskljucen");
            }

        }
    }
}
