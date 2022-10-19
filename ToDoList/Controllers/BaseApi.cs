using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using System.Linq;
using ToDoList.Common.Exceptions;
using ToDoList.Core.Managers.Interfaces;
using ToDoList.ViewModels.ViewModels;

namespace ToDo.Controllers
{
    public class BaseApi : Controller
    {


        private UserModel _TokenUser;

        protected UserModel TokenUser
        { 
            get 
            {  
                if(_TokenUser != null) return _TokenUser;

                Request.Headers.TryGetValue("Authorization", out StringValues Token);

                if (string.IsNullOrEmpty(Token))
                {
                    _TokenUser = null;
                    return _TokenUser;
                }

                var claimId = User.Claims.FirstOrDefault(x => x.Type == "Id");

                if (claimId == null || !int.TryParse(claimId.Value, out int id))
                {
                    throw new ServiceValidationException(401, "Invalid or expire token");
                }
                var commonManager = HttpContext.RequestServices.GetService(typeof(ICommonManager)) as ICommonManager;

                _TokenUser = commonManager.GetinfoUserFromDb(new UserModel { Id = id });
                return _TokenUser;
            }

        }
        public BaseApi()
        {
        }
    }
}
