using Assets.Scripts.DataClasses.Properties.MapItemProperties;
using DataClasses;
using DataClasses.Properties.MapItemProperties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.Networking;

namespace Assets.Scripts.DataClasses.Models
{
    public class PrepareDeleteRequest
    {
        public PrepareDeleteRequest(List<PointProperty> pointDelete, List<TransitionProperties> transitionDelete)
        {
            pointDelete.ForEach(x => DeletePoint(x.BuildingId, x.FroorId, x.Id));
            transitionDelete.ForEach(x => DeleteTransition(x.BuildingId, x.FroorId, x.Id));
        }

        private void DeletePoint(long buildingId, long floorId, int id)
        {
            var request = UnityWebRequest.Delete($"http://195.54.14.121:8086/api/building/{buildingId}/floor/{floorId}/point/{id}");
            request.SetRequestHeader("accept", "*/*");
            request.SetRequestHeader("Content-Type", "application/json; charset=UTF-8");
            request.SetRequestHeader("Authorization", "Bearer " + Config.BearerToken);
            request.SendWebRequest();
        }

        private void DeleteTransition(long buildingId, long floorId, int id)
        {
            var request = UnityWebRequest.Delete($"http://195.54.14.121:8086/api/building/{buildingId}/floor/{floorId}/transition/{id}");
            request.SetRequestHeader("accept", "*/*");
            request.SetRequestHeader("Content-Type", "application/json; charset=UTF-8");
            request.SetRequestHeader("Authorization", "Bearer " + Config.BearerToken);
            request.SendWebRequest();
        }
    }
}
