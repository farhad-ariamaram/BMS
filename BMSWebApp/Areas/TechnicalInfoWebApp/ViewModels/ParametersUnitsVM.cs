using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TechnicalInfoWebApp.ViewModels
{
    public class ParametersUnitsVM
    {
        public Guid[] SelectedIds { get; set; }
        public IEnumerable<SelectListItem> Items { get; set; }
    }
}
