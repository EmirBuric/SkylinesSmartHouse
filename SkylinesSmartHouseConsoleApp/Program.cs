using Microsoft.Extensions.DependencyInjection;
using SkylinesSmartHouseConsoleApp.Azuriraj;
using SkylinesSmartHouseConsoleApp.Controller;
using SkylinesSmartHouseConsoleApp.Dodaj;
using SkylinesSmartHouseConsoleApp.Meniji;
using SkylinesSmartHouseConsoleApp.Modeli;
using SkylinesSmartHouseConsoleApp.Pretrazi;
using SkylinesSmartHouseConsoleApp.Servisi;




public class Program
{
    private static void Main(string[] args)
    {
        var service = new ServiceCollection();

        service.AddTransient<IKucaService, KucaService>();
        service.AddTransient<IUredajService, UredajService>();
        service.AddTransient<ISenzorService, SenzorService>();
        service.AddTransient<ISobaService, SobaService>();
        service.AddTransient<IKorisnikService, KorisnikService>();
        service.AddTransient<KucaController>();
        service.AddTransient<UredajController>();
        service.AddTransient<SenzorController>();
        service.AddTransient<SobaController>();
        service.AddTransient<KorisnikController>();

        var serviceProvider = service.BuildServiceProvider();

        var scope = serviceProvider.CreateScope();

        var kuca = scope.ServiceProvider.GetRequiredService<KucaController>();
        var soba = scope.ServiceProvider.GetRequiredService<SobaController>();
        var senzor = scope.ServiceProvider.GetRequiredService<SenzorController>();
        var uredjaj = scope.ServiceProvider.GetRequiredService<UredajController>();
        var korisnik = scope.ServiceProvider.GetRequiredService<KorisnikController>();




        Console.WriteLine("Dobro dosli u SmartHome");
        Console.WriteLine("Registrujte Vaš račun");

        korisnik.Dodaj();


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
                    var korisnikMenu = new KorisnikMenu(korisnik);
                    korisnikMenu.PrikaziMeni();
                    break;
                case "2":
                    var kucaMenu = new KucaMenu(kuca);
                    kucaMenu.PrikaziMeni();
                    break;
                case "3":
                    var sobaMenu = new SobaMenu(soba);
                    sobaMenu.PrikaziMeni();
                    break;
                case "4":
                    var senzorMenu = new SenzorMenu(senzor);
                    senzorMenu.PrikaziMeni();
                    break;
                case "5":
                    var uredjajMenu = new UredajMenu(uredjaj);
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
