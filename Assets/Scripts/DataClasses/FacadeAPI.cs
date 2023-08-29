using System.Collections.Generic;
using System.Text;
using DataClasses.Models.Requests;
using UnityEngine;
using UnityEngine.Networking;

namespace DataClasses
{
    public class FacadeAPI
    {
        private const string URL = "http://localhost:8000/api";
        
        public IEnumerator<bool> Login(string login, string password)
        {
            var loginRequest = new LoginRequest
            {
                login = login,
                password = password
            };
            var json = JsonUtility.ToJson(loginRequest);
            var request = PreparePostRequest(json, $"{URL}/auth/login");

            request.SendWebRequest();

            yield return request.isDone && request.responseCode == 200L;
        }
        
        private static UnityWebRequest PreparePostRequest(string json, string url)
        {
            var formData = new WWWForm();
            var request = UnityWebRequest.Post(url, formData);
            
            var postBytes = Encoding.UTF8.GetBytes(json);
            var uploadHandler = new UploadHandlerRaw(postBytes);
            request.uploadHandler = uploadHandler;
            
            request.SetRequestHeader("accept", "*/*");
            request.SetRequestHeader("Content-Type", "application/json; charset=UTF-8");

            return request;
        }
    }
}