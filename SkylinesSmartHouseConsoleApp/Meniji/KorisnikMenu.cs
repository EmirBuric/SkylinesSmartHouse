using SkylinesSmartHouseConsoleApp.Controller;
using SkylinesSmartHouseConsoleApp.Modeli;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkylinesSmartHouseConsoleApp.Meniji
{
    public class KorisnikMenu : BaseMenu<KorisnikController>
    {
        public KorisnikMenu(KorisnikController controller) : base(controller)
        {
        }

        public override void PrikaziMeni()
        {
            bool exit = false;


            while (!exit)
            {
                Console.WriteLine("Odaberite opciju");
                Console.WriteLine("1. Pogledaj profil");
                Console.WriteLine("2. Azuriraj profil");
                Console.WriteLine("3. Izlaz");
                string opcija = Console.ReadLine();

                switch (opcija)
                {
                    case "1":
                        _controller.Info();
                        break;
                    case "2":
                        _controller.Azuriraj();
                        break;
                    case "3":
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
