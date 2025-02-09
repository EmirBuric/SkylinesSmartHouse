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
        service.AddTransient<ISenzorService, SenzorService>();
        service.AddTransient<KucaController>();
        service.AddTransient<SenzorController>();

        var serviceProvider = service.BuildServiceProvider();

        var scope = serviceProvider.CreateScope();

        var kuca = scope.ServiceProvider.GetRequiredService<KucaController>();
        var senzor = scope.ServiceProvider.GetRequiredService<SenzorController>();


       

       

        bool exit=false;

        while(!exit)
        {
            Console.WriteLine("Odaberite opciju");
            Console.WriteLine("1. Dodaj senzor");
            Console.WriteLine("2. Pretraga");
            Console.WriteLine("3. Azuriraj senzor");
            Console.WriteLine("4. Izlaz");
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
                    exit=true;
                    break;
                default:
                    Console.WriteLine("Pogresan unos");
                    break;
            }
        }

        

    }
}