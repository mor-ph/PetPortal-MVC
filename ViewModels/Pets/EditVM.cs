using DA.Entities;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using MVC_proj.Models;
using DA.Repositories;

namespace MVC_proj.ViewModels.Pets
{
    public class EditVM
    {
        public int Id { get; set; }
        [DisplayName("Name:")]
        [Required(ErrorMessage = "This field is Required!")]
        public string Name { get; set; }
        [DisplayName("Breed:")]
        [Required(ErrorMessage = "This field is Required!")]
        public string Breed { get; set; }
        [DisplayName("Owner:")]
        [Required(ErrorMessage = "This field is Required!")]
        public int User_Id { get; set; }
        [DisplayName("Vaccines:")]
        public List<CheckBoxItem> Selected { get; set; }
        public List<Vaccine> Vaccines { get; set; }
        public VaccinesRepository Repo { get; set; }


        public EditVM()
        {
            Selected = new List<CheckBoxItem>();
        }

        public EditVM(Pet item)
        {
            Selected = new List<CheckBoxItem>();

            Id = item.Id;
            Name = item.Name;
            Breed = item.Breed;
            User_Id = (item.UserId == 0) ? AuthenticationManager.LoggedUser.Id : item.UserId;
            
        }

        public void PopulateEntity(Pet item)
        {
            //Selected = this.Selected;
            //item.Vaccines = new List<Vaccine>();
            item.Id = Id;
            item.Name = Name;
            item.Breed = Breed;
            item.UserId = User_Id;
        }
    }
}
