using Assets.Scripts.DataClasses.Models.Responses;
using DataClasses;
using DataClasses.Models.Requests;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

namespace ControllerClients
{
    public class TransitionsControllerClient
    {
        public async Task<GetAllTransitionsResponse?> GetAllTransitions(int buildingId, int floorNumber)
        {
            var url = $"http://195.54.14.121:87/api/building/{buildingId}/floor/{floorNumber}/transition";
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
                var response =
                    JsonUtility.FromJson<GetAllTransitionsResponse>("{\"transitions\":" + responseJson + "}");
                return response;
            }

            Debug.Log(www.error);
            return null;
        }

        public async Task<bool> CreateTransition(
            CreateTransitionRequest request,
            int buildingId,
            int floorNumber
            )
        {
            var url = $"http://195.54.14.121:87/api/building/{buildingId}/floor/{floorNumber}/transition";
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

        public async Task<bool> UpdateTransition(
            UpdateTransitionRequest request,
            int buildingId,
            int floorNumber,
            int transitionId
        )
        {
            var url = $"http://195.54.14.121:87/api/building/{buildingId}/floor/{floorNumber}/transition/{transitionId}";
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

        public async Task<bool> DeleteTransition(
            int buildingId,
            int floorNumber,
            int transitionId
            )
        {
            var url =
                $"http://195.54.14.121:87/api/building/{buildingId}/floor/{floorNumber}/transition/{transitionId}";
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