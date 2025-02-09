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
    public class SobaService:BaseService<Soba,SobaPretraga,SobaDodaj,SobaAzuriraj>,ISobaService
    {
        protected override int GetId(Soba model)
        {
            return model.Id;
        }

        protected override void SetId(Soba model, int id)
        {
            model.Id = id;
        }

        protected override Soba PrebaciUModel(SobaDodaj insert)
        {
            return new Soba { Naziv = insert.Naziv, Povrsina = insert.Povrsina };
        }
        protected override Soba UpdateModel(Soba model, SobaAzuriraj? update)
        {
            model.Naziv = update.Naziv;
            model.Povrsina = update.Povrsina;
            return model;
        }
    }
}
