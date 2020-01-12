using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_proj.ViewModels.Shared
{
    public class PagerVM
    {
        public int Page { get; set; }
        public int PagesCount { get; set; }
        public int ItemsPerPage { get; set; }
    }
}