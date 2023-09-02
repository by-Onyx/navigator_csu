using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.DataClasses
{
    [DefaultValue(FirstFloor)]
    public enum FloorSelect : byte
    {
        ZeroFloor = 0,
        FirstFloor = 1,
        SecondFloor = 2,
        ThirdFloor = 3,
        FourthFloor = 4
    }
}
