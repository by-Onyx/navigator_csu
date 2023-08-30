using System;

namespace DataClasses.Models
{
    [Serializable]
    public struct TransitionModel
    {
        public int id;
        public TransitionTypeModel transitionType;
        public float x;
        public float y;
    }
}