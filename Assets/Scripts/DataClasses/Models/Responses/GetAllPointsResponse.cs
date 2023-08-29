using System;
using UnityEngine.Serialization;

namespace DataClasses.Models.Responses
{
    [Serializable]
    public struct GetAllPointsResponse
    {
        public PointModel[] points;
    }
}