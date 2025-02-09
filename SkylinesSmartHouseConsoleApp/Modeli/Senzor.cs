using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace SkylinesSmartHouseConsoleApp.Modeli
{
    public class Senzor
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public bool Ukljucen { get; set; }= false;
        public int SobaId { get; set; }
    }
}
