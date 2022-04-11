using CommerceTest.Domain.Entities.Base;

namespace CommerceTest.Domain.Entities
{
    public class User : Entity
    {
        public User(string? userName, string? password, string? confirmPassword, Guid clienteId)
        {
            UserName = userName;
            Password = password;
            ConfirmPassword = confirmPassword;
            ClienteId = clienteId;
        }

        public string? UserName { get; private set; }
        public string? Password { get; private set; }
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
        public virtual Guid ClienteId { get; private set; }
    }
}
