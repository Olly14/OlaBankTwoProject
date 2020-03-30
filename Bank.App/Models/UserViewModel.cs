using System.Collections.Generic;


namespace Bank.App.Models
{
    public class UserViewModel
    {
        public string SubjectId { get; set; }



        public string Password { get; set; }

        public bool IsActive { get; set; }

        public bool IsBlocked { get; set; }

        public List<UserClaimViewModel> Claims { get; set; }
        public List<UserLoginViewModel> Logins { get; set; }

        public string Email { get; internal set; }
        public string Username { get; internal set; }
    }
}
