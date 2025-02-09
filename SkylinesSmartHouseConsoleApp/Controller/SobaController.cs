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
    public class SobaController
    {
        private readonly ISobaService _service;

        public SobaController(ISobaService service)
        {
            _service = service;
        }

        public void Dodaj()
        {
            var dodajSobu = new SobaDodaj();

            Console.WriteLine("Zdravo, unesite naziv sobe:");
            dodajSobu.Naziv = Console.ReadLine();
            while (string.IsNullOrEmpty(dodajSobu.Naziv))
            {
                Console.WriteLine("Molimo Vas da unesete naziv");
                dodajSobu.Naziv = Console.ReadLine();
            }
            Console.WriteLine("Unesite povsinu u m^2");
            string unos = Console.ReadLine();
            int temp;
            while (!Int32.TryParse(unos, out temp))
            {
                Console.WriteLine("Molimo Vas da unesete povrsinu");
                unos = Console.ReadLine();
            }
            dodajSobu.Povrsina = temp;

            Console.WriteLine("Unesite Id kuce kojoj soba pripada, ukoliko imate samo jednu kucu unesite 1");
            string unosId= Console.ReadLine();
            int id;
            while (!Int32.TryParse(unosId, out id))
            {
                Console.WriteLine("Molimo Vas da unesete id");
                unosId = Console.ReadLine();
            }
            dodajSobu.KucaId = id;

            _service.Insert(dodajSobu);
            Console.WriteLine("Soba dodana");

        }

        public void Pretraga()
        {
            var pretraga = new SobaPretraga();
            Console.WriteLine("Pretrazite sobe po nazivu");
            pretraga.Naziv = Console.ReadLine();


            var sobe = _service.GetSearchRes(pretraga);

            foreach (Soba soba in sobe)
            {
                Console.WriteLine($"Soba,GetSearch: {soba.Naziv}, {soba.Povrsina} m^2, Id:{soba.Id}");
            }
            Console.WriteLine("Pretraga zavrsena");
        }

        public void Azuriraj()
        {
            var update = new SobaAzuriraj();

            Console.WriteLine("Azuriranje sobe");
            Console.WriteLine("Unesite Id sobe koju zelite azurirat");
            string unos = Console.ReadLine();
            int Id;
            while (!Int32.TryParse(unos, out Id))
            {
                Console.WriteLine("Molimo Vas da unesete Id");
                unos = Console.ReadLine();
            }

            Console.WriteLine("Unesite novi naziv sobe: ");
            update.Naziv = Console.ReadLine();
            while (string.IsNullOrEmpty(update.Naziv))
            {
                Console.WriteLine("Molimo Vas da unesete naziv");
                update.Naziv = Console.ReadLine();
            }
            int temp;
            Console.WriteLine("Unesite povsinu u m^2");
            string unosUpdatePov = Console.ReadLine();
            while (!Int32.TryParse(unosUpdatePov, out temp))
            {
                Console.WriteLine("Molimo Vas da unesete povrsinu");
                unosUpdatePov = Console.ReadLine();
            }
            update.Povrsina = temp;

            _service.Update(Id, update);
            Console.WriteLine("Soba je azurirana");
        }
    }
}
