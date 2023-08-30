using Assets.Scripts.DataClasses.Properties.MapItemProperties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.DataClasses.Models.Mappers
{
    public static class TransitionMapper
    {
        public static TransitionProperties MapTransition(TransitionModel model)
        {
            return new TransitionProperties
            {
                Id = model.id,
                TransitionClass = model.transitionType.id,
                X = model.x,
                Y = model.y
            };
        }
    }
}
