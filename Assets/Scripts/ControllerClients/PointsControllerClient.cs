using DataClasses;
using DataClasses.Models.Requests;
using DataClasses.Models.Responses;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

namespace ControllerClients
{
    public class PointsControllerClient
    {
        public async Task<GetAllPointsResponse?> GetAllPoints(int buildingId, int floorNumber)
        {
            var url = $"http://195.54.14.121:87/api/building/{buildingId}/floor/{floorNumber}/point";
            using var www = UnityWebRequest.Get(url);

            www.SetRequestHeader("accept", "*/*");
            www.SetRequestHeader("Content-Type", "application/json; charset=UTF-8");

            var operation = www.SendWebRequest();

            while (!operation.isDone)
            {
                await Task.Yield();
            }

            if (www.result == UnityWebRequest.Result.Success)
            {
                var responseJson = Encoding.UTF8.GetString(www.downloadHandler.data);
                var response = JsonUtility.FromJson<GetAllPointsResponse>("{\"points\":" + responseJson + "}");
                return response;
            }

            Debug.Log(www.error);
            return null;
        }

        public async Task<bool> CreatePoint(
            CreatePointRequest request,
            int buildingId,
            int floorNumber)
        {
            var url = $"http://195.54.14.121:87/api/building/{buildingId}/floor/{floorNumber}/point";
            using var www = UnityWebRequest.Post(url, new WWWForm());

            www.SetRequestHeader("accept", "*/*");
            www.SetRequestHeader("Content-Type", "application/json; charset=UTF-8");
            www.SetRequestHeader("Authorization", "Bearer " + Config.JwtToken);

            var json = JsonUtility.ToJson(request);
            var jsonBytes = Encoding.UTF8.GetBytes(json);

            www.uploadHandler = new UploadHandlerRaw(jsonBytes);

            var operation = www.SendWebRequest();

            while (!operation.isDone)
            {
                await Task.Yield();
            }

            if (www.result == UnityWebRequest.Result.Success)
            {
                return true;
            }

            Debug.Log(www.error);
            return false;
        }

        public async Task<bool> UpdatePoint(
            UpdatePointRequest request,
            int buildingId,
            int floorNumber,
            int pointId
            )
        {
            var url = $"http://195.54.14.121:87/api/building/{buildingId}/floor/{floorNumber}/point/{pointId}";
            var requestJson = JsonUtility.ToJson(request);
            using var www = UnityWebRequest.Put(url, requestJson);

            www.SetRequestHeader("accept", "*/*");
            www.SetRequestHeader("Content-Type", "application/json; charset=UTF-8");
            www.SetRequestHeader("Authorization", "Bearer " + Config.JwtToken);

            var operation = www.SendWebRequest();

            while (!operation.isDone)
            {
                await Task.Yield();
            }

            if (www.result == UnityWebRequest.Result.Success)
            {
                return true;
            }

            Debug.Log(www.error);
            return false;
        }

        public async Task<bool> DeletePoint(
            int buildingId,
            int floorNumber,
            int pointId
            )
        {
            var url = $"http://195.54.14.121:87/api/building/{buildingId}/floor/{floorNumber}/point/{pointId}";
            using var www = UnityWebRequest.Delete(url);

            www.SetRequestHeader("accept", "*/*");
            www.SetRequestHeader("Content-Type", "application/json; charset=UTF-8");
            www.SetRequestHeader("Authorization", "Bearer " + Config.JwtToken);

            var operation = www.SendWebRequest();

            while (!operation.isDone)
            {
                await Task.Yield();
            }

            if (www.result == UnityWebRequest.Result.Success)
            {
                return true;
            }

            Debug.Log(www.error);
            return false;
        }
    }
}