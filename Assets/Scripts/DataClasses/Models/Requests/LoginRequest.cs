using System;

namespace DataClasses.Models.Requests
{
    [Serializable]
    public struct LoginRequest
    {
        public string login;
        public string password;
    }
}