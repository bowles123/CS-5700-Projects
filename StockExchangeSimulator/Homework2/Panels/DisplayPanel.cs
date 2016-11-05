using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panels
{
    public interface DisplayPanel : Observer
    {
        void updateGui();
    }
}
