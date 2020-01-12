using DA.Entities;
using MVC_proj.ViewModels.Shared;
using System.Collections.Generic;

namespace MVC_proj.ViewModels.Users
{
    public class IndexVM
    {
        public FilterVM Filter { get; set; }
        public PagerVM Pager { get; set; }
        public List<User> Items { get; set; }
    }
}