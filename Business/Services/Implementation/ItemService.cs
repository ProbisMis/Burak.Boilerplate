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
    public class ItemService : IItemService
    {
        private readonly DataContext _dataContext;
        private readonly IConfiguration _configuration;
        private readonly ILogger<ItemService> _logger;

        public ItemService(DataContext dataContext, 
            IConfiguration configuration, ILogger<ItemService> logger)
        {
            _dataContext = dataContext;
            _configuration = configuration;
            _logger = logger;
        }

        public async Task<Item> CreateItem(Item item)
        {
            var addedItem = _dataContext.Items.Add(item);
            await _dataContext.SaveChangesAsync();

            return addedItem.Entity;
        }

        public async Task<IList<Item>> GetAll()
        {
            var items = _dataContext.Items;

            return items.ToList();
        }

        public async Task<Item> GetItemById(int itemId)
        {
            var item = _dataContext.Items.Find(itemId);

            return item;
        }

        public async Task<Item> UpdateItem(Item item)
        {
            var updatedItem = _dataContext.Items.Update(item);
            await _dataContext.SaveChangesAsync();

            return updatedItem.Entity;
        }
    }
}
