using System;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using DA.Entities;

namespace MVC_proj.ViewModels.Pets
{
    public class FilterVM 
    {
        public int Id { get; set; }
        [DisplayName("Name:")]
        public string Name { get; set; }
        [DisplayName("Breed:")]
        public string Breed { get; set; }
        [DisplayName("Owner:")]
        public int UserId { get; set; }

        public Expression<Func<Pet, bool>> GenerateFilter()
        {
            return i => (string.IsNullOrEmpty(Name) || i.Name.Contains(Name)) &&
                        (string.IsNullOrEmpty(Breed) || i.Breed.Contains(Breed));
        }
    }
}