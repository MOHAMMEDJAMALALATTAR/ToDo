using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Common.Exceptions;

namespace ToDoList.ViewModels.ViewModels
{
    public class ToDoListRespones
    {
        public PagedResult<ToDoListModelView> Blog { get; set; }
        public Dictionary<int, UserModel> User { get; set; }

    }
}
