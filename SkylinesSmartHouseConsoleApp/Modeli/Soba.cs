using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkylinesSmartHouseConsoleApp.Modeli
{
    public class Soba
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public int Povrsina { get; set; }
        public List<Uredaj>? Uredaji { get; set; }
        public List<Senzor>? Senzori { get; set; }
    }
}
