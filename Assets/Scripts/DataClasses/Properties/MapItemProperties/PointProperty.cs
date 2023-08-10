﻿using System;

namespace Assets.Scripts.DataClasses.Properties.MapItemProperties
{
    [Serializable]
    public class PointProperty : MapItemProperty
    {
        public int PointClass;

        public string TextFirst;
        public string TextSecond;
        public string TextThird;

        public PointProperty() { }

        public PointProperty(float x, float y) : base(x, y) { }
    }
}