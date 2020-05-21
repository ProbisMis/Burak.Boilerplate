using AutoMapper.Configuration;
using Burak.Boilerplate.Business.Services.Interface;
using Burak.Boilerplate.Data;
using Burak.Boilerplate.Data.EntityModels;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Burak.Boilerplate.Business.Services.Implementation
{
    public class UserItemService : IUserItemService
    {
        private readonly DataContext _dataContext;
        private readonly IConfiguration _configuration;
        private readonly IUserService _userService;
        private readonly ILogger<UserItemService> _logger;

        public UserItemService(DataContext dataContext,
            IConfiguration configuration, 
            ILogger<UserItemService> logger,
            IUserService userService
            )
        {
            _dataContext = dataContext;
            _configuration = configuration;
            _logger = logger;
            _userService = userService;
        }

        public async Task<User> CreateUserItem(User user,UserItem item)
        {
            var user1 = await  _userService.GetUserById(user.Id);
            user1.UserItems.Add(item);
            _dataContext.Users.Update(user1);
            await _dataContext.SaveChangesAsync();

            return user1;
        }

        public async Task<IList<UserItem>> GetAllUserItems(int userId)
        {
            var userItems = _dataContext.UserItems.Where(x => x.UserId == userId);
            return userItems.ToList();
        }

        public async Task<UserItem> GetUserItemById(int userId, int itemId)
        {
            var userItem = _dataContext.UserItems.Where(x => x.UserId == userId && x.ItemId == itemId).First();
            return userItem;
        }

        public Task<User> UpdateUserItem(User user, UserItem item)
        {
            throw new NotImplementedException();
        }
    }
}
