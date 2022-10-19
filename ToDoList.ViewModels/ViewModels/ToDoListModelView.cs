using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ToDoList.ViewModels.ViewModels
{
    public  class ToDoListModelView
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public string ImageString { get; set; }
        public string Content { get; set; }
        public bool IsRead { get; set; }

        [Timestamp]
        public DateTime CreatedDate { get; set; }

        
        public int CreaterId { get; set; }
        public int IsSigned { get; set; }

        }
}
