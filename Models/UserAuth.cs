using System;

namespace CoreWebApi.Models {
    public class UserAuth {       
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string EmailAddress { get; set; }

    }
}