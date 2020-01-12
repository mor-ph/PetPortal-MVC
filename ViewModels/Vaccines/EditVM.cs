using DA.Entities;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MVC_proj.ViewModels.Vaccines
{
    public class EditVM
    {
        public int Id { get; set; }
        [DisplayName("Name:")]
        [Required(ErrorMessage = "This field is Required!")]
        public string Name { get; set; }

        public EditVM()
        {
        }

        public EditVM(Vaccine item)
        {
            Id = item.Id;
            Name = item.Name;
        }

        public void PopulateEntity(Vaccine item)
        {
            item.Id = Id;
            item.Name = Name;
        }
    }
}