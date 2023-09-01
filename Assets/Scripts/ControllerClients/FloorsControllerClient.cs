using DataClasses.Models.Responses;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

namespace ControllerClients
{
    public class FloorsControllerClient
    {
        public async Task<GetAllFloorsResponse?> GetAllFloors(int buildingId = 1)
        {

            var url = $"http://195.54.14.121:8086/api/building/{buildingId}/floor";
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
                    JsonUtility.FromJson<GetAllFloorsResponse>("{\"floors\":" + responseJson + "}");
                return response;
            }

            Debug.Log(www.error);
            return null;
        }
    }
}