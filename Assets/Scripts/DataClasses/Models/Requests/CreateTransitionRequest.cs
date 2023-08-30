using Assets.Scripts.DataClasses.Models.Types;
using System;

namespace DataClasses.Models.Requests
{
    [Serializable]
    public struct CreateTransitionRequest
    {
        public int id;
        public TransitionTypeModel transitionType;
        public float x;
        public float y;
    }
}