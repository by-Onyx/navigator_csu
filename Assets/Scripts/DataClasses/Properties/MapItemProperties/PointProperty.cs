﻿using Assets.Scripts.DataClasses.Properties.MapItemProperties;
using DataClasses.Models;

namespace DataClasses.Properties.MapItemProperties
{
    public class PointProperty : MapItemProperty
    {
        public PointTypeModel PointType;

        public string TextFirst;
        public string TextSecond;
        public string TextThird;

        public PointProperty() { }

        public PointProperty(float x, float y) : base(x, y) { }
    }
}
