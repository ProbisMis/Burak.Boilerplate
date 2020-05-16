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
        Task<IList<Item>> GetItemById();
        Task<IList<Item>> CreateItem();
        Task<IList<Item>> UpdateItem();
    }
}
