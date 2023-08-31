using System;

namespace Assets.Scripts.DataClasses.Models.Responses
{
    [Serializable]
    public struct GetAllTransitionsResponse
    {
        public TransitionModel[] transitions;
    }
}
