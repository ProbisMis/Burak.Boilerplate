using Burak.Boilerplate.Data.EntityModels;
using Burak.Boilerplate.Models.Requests;
using Burak.Boilerplate.Models.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Burak.Boilerplate.Business.Services.Interface
{
    public interface IItemService
    {
        Task<IList<Item>> GetAll();
        Task<Item> GetItemById(int itemId);
        Task<Item> CreateItem(Item item);
        Task<Item> UpdateItem(Item item);
    }
}
