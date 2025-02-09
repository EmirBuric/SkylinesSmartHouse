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
    public class SenzorService:BaseService<Senzor, SenzorPretraga, SenzorDodaj, SenzorAzuriraj>, ISenzorService
    {
        protected override int GetId(Senzor model)
        {
            return model.Id;
        }

        protected override void SetId(Senzor model, int id)
        {
            model.Id = id;
        }

        protected override Senzor PrebaciUModel(SenzorDodaj insert)
        {
            return new Senzor { Naziv = insert.Naziv};
        }
        protected override Senzor UpdateModel(Senzor model, SenzorAzuriraj? update)
        {
            model.Naziv = update.Naziv;
            return model;
        }
    }
}
