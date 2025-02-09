using Microsoft.Extensions.DependencyInjection;
using SkylinesSmartHouseConsoleApp.Azuriraj;
using SkylinesSmartHouseConsoleApp.Controller;
using SkylinesSmartHouseConsoleApp.Dodaj;
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

        bool exit=false;


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
                    korisnik.Info();
                    break;
                case "2":
                    korisnik.Azuriraj();
                    break;
                case "3":
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Pogresan unos");
                    break;
            }
        }

        exit = false;
        while (!exit)
        {
            Console.WriteLine("Odaberite opciju");
            Console.WriteLine("1. Dodaj kucu");
            Console.WriteLine("2. Pretraga");
            Console.WriteLine("3. Azuriraj Kucu");
            Console.WriteLine("4. Izlaz");
            string opcija = Console.ReadLine();

            switch (opcija)
            {
                case "1":
                    kuca.Dodaj();
                    break;
                case "2":
                    kuca.Pretraga();
                    break;
                case "3":
                    kuca.Azuriraj();
                    break;
                case "4":
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Pogresan unos");
                    break;
            }
        }
        exit = false;
        while (!exit)
        {
            Console.WriteLine("Odaberite opciju");
            Console.WriteLine("1. Dodaj sobu");
            Console.WriteLine("2. Pretraga");
            Console.WriteLine("3. Azuriraj sobu");
            Console.WriteLine("4. Izlaz");
            string opcija = Console.ReadLine();

            switch (opcija)
            {
                case "1":
                    soba.Dodaj();
                    break;
                case "2":
                    soba.Pretraga();
                    break;
                case "3":
                    soba.Azuriraj();
                    break;
                case "4":
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Pogresan unos");
                    break;
            }
        }
        exit = false;
        while(!exit)
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
                    senzor.Dodaj();
                    break;
                case "2":
                    senzor.Pretraga();
                    break;
                case "3":
                    senzor.Azuriraj();
                    break;
                case "4":
                    senzor.UkljuciSenzor();
                    break;
                case "5":
                    exit=true;
                    break;
                default:
                    Console.WriteLine("Pogresan unos");
                    break;
            }
        }
        exit = false;
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
                    uredjaj.Dodaj();
                    break;
                case "2":
                    uredjaj.Pretraga();
                    break;
                case "3":
                    uredjaj.Azuriraj();
                    break;
                case "4":
                    uredjaj.UkljuciUredjaj();
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