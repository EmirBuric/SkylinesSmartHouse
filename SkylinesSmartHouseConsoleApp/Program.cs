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
        service.AddTransient<ISobaService, SobaService>();
        service.AddTransient<KucaController>();
        service.AddTransient<SobaController>();

        var serviceProvider = service.BuildServiceProvider();

        var scope = serviceProvider.CreateScope();

        var kuca = scope.ServiceProvider.GetRequiredService<KucaController>();
        var soba = scope.ServiceProvider.GetRequiredService<SobaController>();


       

       

        bool exit=false;

        while(!exit)
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
                    exit=true;
                    break;
                default:
                    Console.WriteLine("Pogresan unos");
                    break;
            }
        }

        

    }
}