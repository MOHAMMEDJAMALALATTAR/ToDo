using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Common.Exceptions;
using ToDoList.Data.Models;
using ToDoList.ViewModels.ViewModels;

namespace ToDoList.Core.Mapper
{
    public  class Mapping:Profile
    {
        public Mapping()
        {

            CreateMap<LoginRespones, User>().ReverseMap();
            CreateMap<UserModel, User>().ReverseMap();
            CreateMap<ToDoListModelView, Todo>().ReverseMap();
            CreateMap<PagedResult<ToDoListModelView>, PagedResult<Todo>>().ReverseMap();

        }

    }
}
