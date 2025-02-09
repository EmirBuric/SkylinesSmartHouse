using SkylinesSmartHouseConsoleApp.Controller;
using SkylinesSmartHouseConsoleApp.Modeli;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkylinesSmartHouseConsoleApp.Meniji
{
    public class SenzorMenu : BaseMenu<SenzorController>
    {
        public SenzorMenu(SenzorController controller) : base(controller)
        {
        }

        public override void PrikaziMeni()
        {
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("Odaberite opciju");
                Console.WriteLine("1. Dodaj senzor");
                Console.WriteLine("2. Pretraga");
                Console.WriteLine("3. Azuriraj senzor");
                Console.WriteLine("4. Upali/ugasi senzor");
                Console.WriteLine("5. Izlaz");
                string opcija = Console.ReadLine();

                switch (opcija)
                {
                    case "1":
                        _controller.Dodaj();
                        break;
                    case "2":
                        _controller.Pretraga();
                        break;
                    case "3":
                        _controller.Azuriraj();
                        break;
                    case "4":
                        _controller.UkljuciSenzor();
                        break;
                    case "5":
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
