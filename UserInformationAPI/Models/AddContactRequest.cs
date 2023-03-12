﻿namespace UserInformationAPI.Models
{
    public class AddContactRequest
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public long Phone { get; set; } 
        public string Address{ get; set; }

    }
}
