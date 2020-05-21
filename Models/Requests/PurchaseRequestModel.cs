using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Burak.Boilerplate.Models.Requests
{
    /// <summary>
    /// Model contains List of Items to be purchased, Total Cost, UserId
    /// </summary>
    public class PurchaseRequestModel
    {
        public int CustomerId { get; set; }
        public int PurchaseTotal { get; set; }
        public List<ItemRequest> Items { get; set; }


    }
}
