using Assets.Scripts.DataClasses.Models.Types;
using System;

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
