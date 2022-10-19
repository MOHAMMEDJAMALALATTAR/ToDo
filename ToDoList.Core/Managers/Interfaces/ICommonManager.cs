using ToDoList.ViewModels.ViewModels;

namespace ToDoList.Core.Managers.Interfaces
{
    public interface ICommonManager
    {
        public UserModel GetinfoUserFromDb(UserModel userModel);
    }
}
