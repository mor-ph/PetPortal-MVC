using DA.Entities;
using MVC_proj.ViewModels.Shared;
using MVC_proj.ViewModels.Users;
using System.Collections.Generic;

namespace MVC_proj.ViewModels.Pets
{
    public class IndexVM
    {
        public FilterVM Filter { get; set; }
        public PagerVM Pager { get; set; }

        public List<Pet> Items { get; set; }
    }
}