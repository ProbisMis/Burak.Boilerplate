using Burak.Boilerplate.Models.BaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Burak.Boilerplate.Data.EntityModels
{
    public class UserItem : IEntity<int>
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User{ get; set; }

        public int ItemId { get; set; }
        public Item Item { get; set; }

        public bool IsEquipped { get; set; }
        public bool IsConsumed { get; set; }
        public int ItemLevel { get; set; }
        public int Quantity { get; set; }
    }
}
