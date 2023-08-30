using Assets.Scripts.DataClasses.Properties.MapItemProperties;
using DataClasses.Models;

namespace DataClasses
{
    public static class TransitionMapper
    {
        public static TransitionProperties Map(TransitionModel model)
        {
            return new TransitionProperties
            {
                X = model.x,
                Y = model.y,
                Id = model.id,
                TransitionClass = model.transitionType.id
            };
        }
    }
}