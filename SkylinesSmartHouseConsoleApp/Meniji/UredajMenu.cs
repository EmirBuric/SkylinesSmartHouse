using SkylinesSmartHouseConsoleApp.Controller;
using SkylinesSmartHouseConsoleApp.Modeli;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkylinesSmartHouseConsoleApp.Meniji
{
    public class UredajMenu : BaseMenu<UredajController>
    {
        public UredajMenu(UredajController controller) : base(controller)
        {
        }

        public override void PrikaziMeni()
        {
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("Odaberite opciju");
                Console.WriteLine("1. Dodaj uredjaj");
                Console.WriteLine("2. Pretraga");
                Console.WriteLine("3. Azuriraj uredjaj");
                Console.WriteLine("4. Upali/ugasi uredjaj");
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
                        _controller.UkljuciUredjaj();
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
