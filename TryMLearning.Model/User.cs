using System.Collections.Generic;
using Microsoft.AspNet.Identity;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using TryMLearning.Model.Constants;

namespace TryMLearning.Model
{
    public class User : IUser
    {
        public int UserId { get; set; }

        string IUser<string>.Id => UserId.ToString();

        public string UserName { get; set; }

        public string Email { get; set; }

        [JsonIgnore]
        public string PasswordHash { get; set; }
    }
}
