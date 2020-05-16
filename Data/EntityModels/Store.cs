using Burak.Boilerplate.Models.BaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Burak.Boilerplate.Data.EntityModels
{
    public class Store : IEntity<int>
    {
        public int Id { get; set; }
    }
}
