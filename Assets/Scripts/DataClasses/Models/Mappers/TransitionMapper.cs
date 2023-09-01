using Assets.Scripts.DataClasses.Properties.MapItemProperties;

namespace Assets.Scripts.DataClasses.Models.Mappers
{
    public static class TransitionMapper
    {
        public static TransitionProperties MapTransition(TransitionModel model)
        {
            return new TransitionProperties
            {
                Id = model.id,
                TransitionType = model.transitionType,
                X = model.x,
                Y = model.y
            };
        }
    }
}
