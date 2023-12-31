﻿using System;

namespace DataClasses.Models.Requests
{
    [Serializable]
    public struct UpdatePointRequest
    {
        public int id;
        public PointTypeModel pointType;
        public string firstField;
        public string secondField;
        public string thirdField;
        public float x;
        public float y;
    }
}