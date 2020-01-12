using DA.Entities;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace MVC_proj.ViewModels.Users
{
    public class EditVM
    {
        public int Id { get; set; }
        [DisplayName("Username:")]
        [Required(ErrorMessage = "This field is Required!")]
        public string Username { get; set; }
        [DisplayName("Password:")]
        [Required(ErrorMessage = "This field is Required!")]
        public string Password { get; set; }
        [DisplayName("First Name:")]
        [Required(ErrorMessage = "This field is Required!")]
        public string FirstName { get; set; }
        [DisplayName("Last Name:")]
        [Required(ErrorMessage = "This field is Required!")]
        public string LastName { get; set; }            

        public EditVM() { }

        public EditVM(User item)
        {
            Id = item.Id;
            Username = item.Username;
            Password = item.Password;
            FirstName = item.FirstName;
            LastName = item.LastName;
        }

        public void PopulateEntity(User item)
        {
            item.Id = Id;
            item.Username = Username;
            item.Password = Password;
            item.FirstName = FirstName;
            item.LastName = LastName;
        }
    }
}