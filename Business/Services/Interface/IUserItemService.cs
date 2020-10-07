using Burak.Boilerplate.Data.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Burak.Boilerplate.Business.Services.Interface
{
    public interface IUserItemService
    {
        Task<IList<UserItem>> GetAllUserItems(int userId);
        Task<UserItem> GetUserItemById(int userId, int itemId);
        Task<User> CreateUserItem(UserItem userItem);
        Task<UserItem> UpdateUserItem(UserItem userItem);
        Task DeleteUserItem(UserItem userItem);
    }
}
