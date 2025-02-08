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

        var kuca = kucaServis.GetById(1);

        Console.WriteLine($"Kuća dodata,getById: {kuca.Naziv}, {kuca.Povrsina} m^2");

        var kuce = kucaServis.GetSearchRes(new KucaPretraga { Naziv = "Moja Kuca 1" });

        foreach (Kuca kuca1 in kuce)
        {
            Console.WriteLine($"Kuća dodata,GetSearch: {kuca1.Naziv}, {kuca1.Povrsina} m^2");
        }     

        kucaServis.Update(1, new KucaAzuriraj { Naziv = "Moja kuca update", Povrsina =134 });

        Console.WriteLine($"Kuća update,getById: {kuca.Naziv}, {kuca.Povrsina} m^2");
    }
}