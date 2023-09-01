using DataClasses.Models;
using DataClasses.Properties.MapItemProperties;

namespace DataClasses
{
    public static class PointMapper
    {
        public static PointProperty MapPoint(PointModel model)
        {
            return new PointProperty
            {
                Id = model.id,
                PointType = model.pointType,
                TextFirst = model.firstField,
                TextSecond = model.secondField,
                TextThird = model.thirdField,
                X = model.x,
                Y = model.y
            };
        }
    }
}