using DataClasses.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.DataClasses.Models.Responses
{
    [Serializable]
    public struct GetAllTransitionsResponse
    {
        public TransitionModel[] transitions;
    }
}
