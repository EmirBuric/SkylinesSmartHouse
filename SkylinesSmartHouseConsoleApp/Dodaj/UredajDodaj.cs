using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkylinesSmartHouseConsoleApp.Dodaj
{
    public class UredajDodaj:BaseDodaj
    {
        public string Proizvodjac { get; set; }
        public string Model { get; set; }
        public int SobaId { get; set; }
        public int SenzorId { get; set; }
    }
}
