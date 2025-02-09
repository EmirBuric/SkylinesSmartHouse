using Microsoft.Extensions.DependencyInjection;
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
    public class KucaController
    {
        private readonly IKucaService _kucaService;

        public KucaController(IKucaService kucaService)
        {
            _kucaService = kucaService;
        }

        public void Dodaj()
        {
            var dodajKucu = new KucaDodaj();

            Console.WriteLine("Zdravo, unesite naziv kuce:");
            dodajKucu.Naziv = Console.ReadLine();
            while (string.IsNullOrEmpty(dodajKucu.Naziv))
            {
                Console.WriteLine("Molimo Vas da unesete naziv");
                dodajKucu.Naziv = Console.ReadLine();
            }
            Console.WriteLine("Unesite povsinu u m^2");
            string unos = Console.ReadLine();
            int temp;
            while (!Int32.TryParse(unos, out temp))
            {
                Console.WriteLine("Molimo Vas da unesete povrsinu");
                unos = Console.ReadLine();
            }
            dodajKucu.Povrsina = temp;
            dodajKucu.KorisnikId = 1;
            _kucaService.Insert(dodajKucu); 
            Console.WriteLine("Kuca dodana");
        }

        public void Pretraga()
        {
            var pretraga = new KucaPretraga();
            Console.WriteLine("Pretrazite kuce po nazivu");
            pretraga.Naziv = Console.ReadLine();
            while (string.IsNullOrEmpty(pretraga.Naziv))
            {
                Console.WriteLine("Molimo Vas da unesete naziv");
                pretraga.Naziv = Console.ReadLine();
            }


            var kuce = _kucaService.GetSearchRes(pretraga);

            foreach (Kuca kuca in kuce)
            {
                Console.WriteLine($"Kuća,GetSearch: {kuca.Naziv}, {kuca.Povrsina} m^2, Id:{kuca.Id}");
            }
            Console.WriteLine("Pretraga zavrsena");
        }

        public void Azuriraj()
        {
            var update = new KucaAzuriraj();

            Console.WriteLine("Azuriranje kuce");
            Console.WriteLine("Unesite Id kuce koju zelite azurirat");
            string unos = Console.ReadLine();
            int Id;
            while (!Int32.TryParse(unos, out Id))
            {
                Console.WriteLine("Molimo Vas da unesete Id");
                unos = Console.ReadLine();
            }

            Console.WriteLine("Unesite novi naziv kuce: ");
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

            _kucaService.Update(Id, update);
            Console.WriteLine("Kuca je azurirana");
        }
    }
}
