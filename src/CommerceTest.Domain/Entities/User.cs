﻿using CommerceTest.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CommerceTest.Domain.Entities
{
    public class User : Entity
    {
        public User(string? userName, string? password)
        {
            UserName = userName;
            Password = password;
        }

        public string? UserName { get; private set; }
        public string? Password { get; private set; }
        [JsonIgnore]
        [NotMapped]
        public string? ConfirmPassword { get; private set; }

        public bool VerifyPassword(string pass, string confirmPass)
        {
            if (pass == confirmPass )
            {
                return true;
            }
            return false;
        }

        //EF

        public virtual Cliente Cliente { get; set; }
    }
}
