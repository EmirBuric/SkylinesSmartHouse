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
        service.AddTransient<KucaController>();
        service.AddTransient<UredajController>();
        service.AddTransient<SenzorController>();
        service.AddTransient<SobaController>();

        var serviceProvider = service.BuildServiceProvider();

        var scope = serviceProvider.CreateScope();

        var kuca = scope.ServiceProvider.GetRequiredService<KucaController>();
        var soba = scope.ServiceProvider.GetRequiredService<SobaController>();
        var senzor = scope.ServiceProvider.GetRequiredService<SenzorController>();
        var uredjaj = scope.ServiceProvider.GetRequiredService<UredajController>();


       

       

        bool exit=false;

        while(!exit)
        {
            Console.WriteLine("Odaberite opciju");
            Console.WriteLine("1. Dodaj uredjaj");
            Console.WriteLine("2. Pretraga");
            Console.WriteLine("3. Azuriraj uredjaj");
            Console.WriteLine("4. Ukljucite uredjaj");
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
                    exit=true;
                    break;
                default:
                    Console.WriteLine("Pogresan unos");
                    break;
            }
        }

        

    }
}