

using AutoMapper;
using System.Linq;
using ToDoList.Common.Exceptions;
using ToDoList.Core.Managers.Interfaces;
using ToDoList.Data.Models;
using ToDoList.ViewModels.ViewModels;

namespace ToDoList.Core.Managers
{
    public class CommonManager : ICommonManager
    {
        private readonly tododbContext _context;
        private readonly IMapper _mapper;

        public CommonManager(tododbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public UserModel GetinfoUserFromDb(UserModel userModel)
        {
            var dbUser = _context.Users
                            .FirstOrDefault(x => x.Id == userModel.Id)
                            ?? throw new ServiceValidationException("Invalid email or password");
            return _mapper.Map<UserModel>(dbUser);
        }


    }
}
