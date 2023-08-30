using System;

namespace DataClasses.Models.Requests
{
    [Serializable]
    public struct UpdateTransitionRequest
    {
        public int id;
        public TransitionTypeModel transitionType;
        public float x;
        public float y;
    }
}