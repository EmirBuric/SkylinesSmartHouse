using SkylinesSmartHouseConsoleApp.Pretrazi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkylinesSmartHouseConsoleApp.Servisi
{
    public class BaseService<TModel, TSearch, TInsert, TUpdate> : IService<TModel, TSearch, TInsert, TUpdate> where TModel : class where TSearch : Pretrazi.BasePretraga
    {

        protected List<TModel> _podaci= new List<TModel>();
        protected int _nextId = 1;

        public virtual TModel GetById(int id)
        {
            return _podaci.FirstOrDefault(x=>GetId(x)==id);
        }

        public virtual List<TModel> GetSearchRes(TSearch search)
        {
           if (string.IsNullOrEmpty(search.Naziv))
               return _podaci;

           var pretraga= new List<TModel>();
            foreach (var item in _podaci)
            {
                var mogucaPretraga = item.GetType()
                    .GetProperties()
                    .Where(p => p.PropertyType == typeof(string))
                    .ToList();

                foreach (var item1 in mogucaPretraga)
                {
                    var check = item1.GetValue(item).ToString();

                    if (!string.IsNullOrEmpty(check) && check.Contains(search.Naziv)) 
                    {
                        pretraga.Add(item);
                        break;
                    }
                }
            }
            return pretraga;
        }

        public virtual TModel Insert(TInsert insert)
        {
            TModel model= PrebaciUModel(insert);
            SetId(model,_nextId++);
            _podaci.Add(model);
            return model;
        }

        public virtual TModel Update(int id,TUpdate update)
        {
            var index= _podaci.FindIndex(x=> GetId(x)==id);
            if (index == -1) return null;

            TModel updateModel = UpdateModel(_podaci[index], update);
            SetId(updateModel,id);
            _podaci[index]=updateModel;
            return updateModel;
        }

        protected virtual int GetId(TModel model) { throw new NotImplementedException(); }
        protected virtual TModel PrebaciUModel(TInsert insert) { throw new NotImplementedException(); }
        protected virtual void SetId(TModel model, int id) { throw new NotImplementedException(); }
        protected virtual TModel UpdateModel(TModel model, TUpdate? update) { throw new NotImplementedException(); }





    }
}
