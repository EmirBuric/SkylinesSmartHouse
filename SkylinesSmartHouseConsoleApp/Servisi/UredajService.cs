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
    public class UredajService : BaseService<Uredaj, UredajPretraga, UredajDodaj, UredajAzuriraj>, IUredajService
    {
        protected override int GetId(Uredaj model)
        {
            return model.Id;
        }

        protected override void SetId(Uredaj model, int id)
        {
            model.Id = id;
        }

        protected override Uredaj PrebaciUModel(UredajDodaj insert)
        {
            return new Uredaj { Naziv = insert.Naziv, Model=insert.Model, Proizvodjac=insert.Proizvodjac };
        }
        protected override Uredaj UpdateModel(Uredaj model, UredajAzuriraj? update)
        {
            model.Naziv = update.Naziv;
            model.Model = update.Model;
            model.Proizvodjac = update.Proizvodjac;
            return model;
        }
        public void Ukljuci(int id)
        {
            var uredjaj = GetById(id);
            if (uredjaj != null)
            {
                uredjaj.Ukljucen = true;
            }
            else 
            {
                Console.WriteLine("Uredaj nije pronadjen");
            }
        }
    }
}
