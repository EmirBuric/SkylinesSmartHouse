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
        service.AddTransient<GlavniMeni>();

        var serviceProvider = service.BuildServiceProvider();

        var scope = serviceProvider.CreateScope();

        var kuca = scope.ServiceProvider.GetRequiredService<KucaController>();
        var soba = scope.ServiceProvider.GetRequiredService<SobaController>();
        var senzor = scope.ServiceProvider.GetRequiredService<SenzorController>();
        var uredjaj = scope.ServiceProvider.GetRequiredService<UredajController>();
        var korisnik = scope.ServiceProvider.GetRequiredService<KorisnikController>();
        var meni = scope.ServiceProvider.GetRequiredService<GlavniMeni>();


        meni.Prikazi();

       
    }




}
