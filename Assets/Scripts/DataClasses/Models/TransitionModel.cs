using Assets.Scripts.DataClasses.Models.Types;
using DataClasses.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.DataClasses.Models
{
    [Serializable]
    public class TransitionModel
    {
        public int id;
        public TransitionTypeModel transitionType;
        public float x;
        public float y;
    }
}
