using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.ViewModels.ViewModels
{
    public class ToDoListRequest
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public string ImageString { get; set; }
        public string Content { get; set; }
        public int IsSigned { get; set; }
        public bool IsRead { get; set; }

    }
}
