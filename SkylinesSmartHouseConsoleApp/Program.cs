using Microsoft.Extensions.DependencyInjection;
using SkylinesSmartHouseConsoleApp.Azuriraj;
using SkylinesSmartHouseConsoleApp.Dodaj;
using SkylinesSmartHouseConsoleApp.Modeli;
using SkylinesSmartHouseConsoleApp.Pretrazi;
using SkylinesSmartHouseConsoleApp.Servisi;




public class Program
{
    private static void Main(string[] args)
    {
        var service = new ServiceCollection();

        service.AddTransient<KucaService>();

        var serviceProvider = service.BuildServiceProvider();

        var scope = serviceProvider.CreateScope();

        var kucaServis = scope.ServiceProvider.GetRequiredService<KucaService>();

        var dodajKucu = new KucaDodaj();

        Console.WriteLine("Zdravo, unesite naziv kuce: ");
        dodajKucu.Naziv = Console.ReadLine();
        while (string.IsNullOrEmpty(dodajKucu.Naziv)) 
        {
            Console.WriteLine("Molimo Vas da unesete naziv");
            dodajKucu.Naziv = Console.ReadLine();
        }
        Console.WriteLine("Unesite povsinu u m^2");
        string unosDodaj= Console.ReadLine();
        int tempDodajPov;
        while (!Int32.TryParse(unosDodaj, out tempDodajPov))
        {
            Console.WriteLine("Molimo Vas da unesete povrsinu");
            unosDodaj = Console.ReadLine();
        }
        dodajKucu.Povrsina = tempDodajPov;

        kucaServis.Insert(dodajKucu);

        kucaServis.Insert(new KucaDodaj
        {
            Naziv = "Moja Kuca",
            Povrsina = 123
        });

        kucaServis.Insert(new KucaDodaj
        {
            Naziv = "Moja Kuca 1",
            Povrsina = 124
        });

        var pretraga= new KucaPretraga();
        Console.WriteLine("Pretrazite kuce po nazivu");
        pretraga.Naziv = Console.ReadLine();
        while (string.IsNullOrEmpty(pretraga.Naziv))
        {
            Console.WriteLine("Molimo Vas da unesete naziv");
            pretraga.Naziv = Console.ReadLine();
        }


        var kuce = kucaServis.GetSearchRes(pretraga);

        foreach (Kuca kuca1 in kuce)
        {
            Console.WriteLine($"Kuća dodata,GetSearch: {kuca1.Naziv}, {kuca1.Povrsina} m^2, Id:{kuca1.Id}");
        }

        var update = new KucaAzuriraj();

        Console.WriteLine("Azuriranje kuce");
        Console.WriteLine("Unesite Id kuce koju zelite azurirat");
        string unosId= Console.ReadLine();
        int tempId;
        while (!Int32.TryParse(unosId, out tempId))
        {
            Console.WriteLine("Molimo Vas da unesete Id");
            unosId = Console.ReadLine();
        }
        int id = tempId;

        Console.WriteLine("Unesite novi naziv kuce: ");
        update.Naziv = Console.ReadLine();
        while (string.IsNullOrEmpty(update.Naziv))
        {
            Console.WriteLine("Molimo Vas da unesete naziv");
            update.Naziv = Console.ReadLine();
        }
        int tempUpdatePov;
        Console.WriteLine("Unesite povsinu u m^2");
        string unosUpdatePov = Console.ReadLine();
        while (!Int32.TryParse(unosUpdatePov, out tempUpdatePov))
        {
            Console.WriteLine("Molimo Vas da unesete povrsinu");
            unosUpdatePov = Console.ReadLine();
        }
        update.Povrsina = tempUpdatePov;


        kucaServis.Update(tempId, update);

        var kuca= kucaServis.GetById(tempId);

        Console.WriteLine($"Kuća update,getById: {kuca.Naziv}, {kuca.Povrsina} m^2");
    }
}