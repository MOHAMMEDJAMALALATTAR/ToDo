using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.ViewModels.ViewModels;

namespace ToDoList.Core.Managers.Interfaces
{
    public interface IUserManager
    {
        public LoginRespones Login(LoginRequest userLogin);
        public LoginRespones SignUp(UserRegistration userReg);
        public UserModel UpdateInfoUser(UserModel currentUser, UserModel userModel);
        public void Delete(UserModel currentUser, int id);
    }
}
