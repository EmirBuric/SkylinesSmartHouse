using SkylinesSmartHouseConsoleApp.Pretrazi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkylinesSmartHouseConsoleApp.Servisi
{
    public interface IService <TModel,TSearch,TInsert,TUpdate> where TModel : class  where  TSearch:BasePretraga
    {
        List<TModel> GetSearchRes(TSearch search);
        TModel GetById(int id);
        TModel Insert(TInsert insert);
        TModel Update(int id,TUpdate update);
    }
}
