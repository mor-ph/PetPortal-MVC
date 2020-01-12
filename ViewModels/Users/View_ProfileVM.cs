using DA.Entities;
using System.ComponentModel;
using System.Collections.Generic;

namespace MVC_proj.ViewModels.Users
{
    public class View_ProfileVM
    {
        public int Id { get; set; }
        [DisplayName("Username:")]
        public string Username { get; set; }
        [DisplayName("Password:")]
        public string Password { get; set; }
        [DisplayName("First Name:")]
        public string FirstName { get; set; }
        [DisplayName("Last Name:")]
        public string LastName { get; set; }
        [DisplayName("Pets:")]
        public List<Pet> Pets { get; set; }

        public View_ProfileVM() { }

        public View_ProfileVM(User item)
        {
            Id = item.Id;
            Username = item.Username;
            Password = item.Password;
            FirstName = item.FirstName;
            LastName = item.LastName;
        }
    }
}