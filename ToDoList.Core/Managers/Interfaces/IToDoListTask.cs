

using ToDoList.ViewModels.ViewModels;

namespace ToDoList.Core.Managers.Interfaces
{
    public interface IToDoListTask
    {
        public ToDoListRespones GetTasks(int page = 1, int pageSize = 10, string sortColumn = "", string sortDirection = "ascending", string searchText = "");
        public ToDoListModelView GetTaskById(int id);
        public ToDoListModelView AddTask(UserModel currentUser, ToDoListRequest  toDoRequest);
        public ToDoListModelView UpdateTask(UserModel currentUser, ToDoListRequest toDoRequest);
        public void DeleteTask(int id);

    }
}
