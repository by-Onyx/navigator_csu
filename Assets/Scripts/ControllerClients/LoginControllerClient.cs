using System.Text;
using System.Threading.Tasks;
using DataClasses.Models.Requests;
using DataClasses.Models.Responses;
using UnityEngine;
using UnityEngine.Networking;

namespace ControllerClients
{
    public class LoginControllerClient
    {
        public async Task<LoginResponse?> LogIn(LoginRequest request)
        {
            const string url = "http://195.54.14.121:8086/api/auth/login";
            using var www = UnityWebRequest.Post(url, new WWWForm());
            
            www.SetRequestHeader("accept", "*/*");
            www.SetRequestHeader("Content-Type", "application/json; charset=UTF-8");

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
                var responseJson = Encoding.UTF8.GetString(www.downloadHandler.data);
                var response = JsonUtility.FromJson<LoginResponse>(responseJson);
                return response;
            }
            
            Debug.Log(www.error);

            return null;
        } 
    }
}