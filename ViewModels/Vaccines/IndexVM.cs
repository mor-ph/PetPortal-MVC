using DA.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_proj.ViewModels.Vaccines
{
    public class IndexVM
    {
        //public FilterVM Filter { get; set; }
        //public PagerVM Pager { get; set; }
        public List<Vaccine> Items { get; set; }
    }
}