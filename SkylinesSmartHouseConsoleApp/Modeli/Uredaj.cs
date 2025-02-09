using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkylinesSmartHouseConsoleApp.Modeli
{
    public class Uredaj
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public string Proizvodjac { get; set; }
        public string Model { get; set; }
        public int SenzorId { get; set; }
        public Senzor Senzor { get; set; }
        public int SobaId { get; set; }
        public Soba Soba { get; set; }
        public bool Ukljucen { get; set; }=false;
    }
}
