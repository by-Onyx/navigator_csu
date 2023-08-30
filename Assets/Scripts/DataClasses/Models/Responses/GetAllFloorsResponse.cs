using System;

namespace DataClasses.Models.Responses
{
    [Serializable]
    public struct GetAllFloorsResponse
    {
        public FloorModel[] floors;
    }
}