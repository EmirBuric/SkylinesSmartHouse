using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkylinesSmartHouseConsoleApp.Meniji
{
    public abstract class BaseMenu<TController>
    {
        protected readonly TController _controller;

        public BaseMenu(TController controller)
        {
            _controller = controller;
        }

        public abstract void PrikaziMeni();
    }
}
