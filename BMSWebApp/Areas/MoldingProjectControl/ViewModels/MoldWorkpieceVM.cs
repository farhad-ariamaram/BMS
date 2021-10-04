using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoldingProjectControlWebApp.ViewModels
{
    public class MoldWorkpieceVM
    {
        public Guid[] SelectedIds { get; set; }
        public IEnumerable<SelectListItem> Items { get; set; }
    }
}
