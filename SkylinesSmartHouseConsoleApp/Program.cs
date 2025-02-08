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
        service.AddTransient<KucaController>();

        var serviceProvider = service.BuildServiceProvider();

        var scope = serviceProvider.CreateScope();

        var kuca = scope.ServiceProvider.GetRequiredService<KucaController>();


       

       

        bool exit=false;

        while(!exit)
        {
            Console.WriteLine("Odaberite opciju");
            Console.WriteLine("1. Dodaj kucu");
            Console.WriteLine("2. Pretraga");
            Console.WriteLine("3. Azuriraj kucu");
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
                    exit=true;
                    break;
                default:
                    Console.WriteLine("Pogresan unos");
                    break;
            }
        }

        

    }
}