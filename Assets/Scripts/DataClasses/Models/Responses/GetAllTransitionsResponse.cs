using System;

namespace DataClasses.Models.Responses
{
    [Serializable]
    public struct GetAllTransitionsResponse
    {
        public TransitionModel[] transitions;
    }
}