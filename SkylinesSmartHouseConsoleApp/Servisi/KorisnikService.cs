using SkylinesSmartHouseConsoleApp.Azuriraj;
using SkylinesSmartHouseConsoleApp.Dodaj;
using SkylinesSmartHouseConsoleApp.Modeli;
using SkylinesSmartHouseConsoleApp.Pretrazi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkylinesSmartHouseConsoleApp.Servisi
{
    public class KorisnikService: BaseService<Korisnik, KorisnikPretraga, KorisnikDodaj, KorisnikAzuriraj>,IKorisnikService
    {
        protected override int GetId(Korisnik model)
        {
            return model.Id;
        }

        protected override void SetId(Korisnik model, int id)
        {
            model.Id = id;
        }

        protected override Korisnik PrebaciUModel(KorisnikDodaj insert)
        {
            return new Korisnik { 
                Ime = insert.Naziv, 
                Prezime=insert.Prezime,
                Email=insert.Email,
                Sifra=insert.Sifra
            };
        }
        protected override Korisnik UpdateModel(Korisnik model, KorisnikAzuriraj? update)
        {
            model.Ime = update.Naziv;
            model.Prezime = update.Prezime;
            model.Email = update.Email;
            model.Sifra = update.Sifra;
            return model;
        }
    }
}
