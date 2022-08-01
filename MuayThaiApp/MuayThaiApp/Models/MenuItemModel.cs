using System;
using System.Collections.Generic;
using System.Text;

namespace MuayThaiApp.Models
{
    public class MenuItemModel
    {
        public int MenuItemId { get; set; }
        public string Title { get; set; }
        public string IconSource { get; set; }
        public string TargetPage { get; set; }
    }
}
