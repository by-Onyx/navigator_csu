using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.DataClasses.Properties.MapItemPopupProperties
{
    public class TransitionPopupProperty 
    {
        public string Header { get; private set; }

        public TransitionPopupProperty(string header) 
        {
            Header = header;
        }
    }
}
