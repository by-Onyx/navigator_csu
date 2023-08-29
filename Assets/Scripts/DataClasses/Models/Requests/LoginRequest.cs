using System;

namespace DataClasses.Models.DTO
{
    [Serializable]
    public struct LoginRequest
    {
        public string login;
        public string password;
    }
}