using Burak.Boilerplate.Business.Services.Interface;
using Burak.Boilerplate.Data.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Burak.Boilerplate.Business.Services.Implementation
{
    public class ItemService : IItemService
    {
        public Task<IList<Item>> CreateItem()
        {
            throw new NotImplementedException();
        }

        public Task<IList<Item>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<IList<Item>> GetItemById()
        {
            throw new NotImplementedException();
        }

        public Task<IList<Item>> UpdateItem()
        {
            throw new NotImplementedException();
        }
    }
}
