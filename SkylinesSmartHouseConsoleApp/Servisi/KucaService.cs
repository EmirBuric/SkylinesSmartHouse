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
    public class KucaService:BaseService<Kuca,KucaPretraga,KucaDodaj,KucaAzuriraj>,IKucaSevice
    {
        protected override int GetId(Kuca model)
        {
            return model.Id;
        }

        protected override void SetId(Kuca model, int id)
        {
            model.Id = id;
        }

        protected override Kuca PrebaciUModel(KucaDodaj insert)
        {
            return new Kuca {Naziv=insert.Naziv,Povrsina=insert.Povrsina };
        }
        protected override Kuca UpdateModel(Kuca model, KucaAzuriraj? update)
        {
            model.Naziv = update.Naziv;
            model.Povrsina = update.Povrsina;
            return model;
        }
    }
}
