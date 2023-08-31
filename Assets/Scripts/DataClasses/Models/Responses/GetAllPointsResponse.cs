using System;

namespace DataClasses.Models.Responses
{
    [Serializable]
    public struct GetAllPointsResponse
    {
        public PointModel[] points;
    }
}