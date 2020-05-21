using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Burak.Boilerplate.Models.Requests
{
    public class ItemRequest
    {
        public string? Title { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? AndroidGameId { get; set; }
        public string? AppleGameId { get; set; }
        public bool? IsConsumable { get; set; }
        public bool? IsUpgradable { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
        public string? PictureUrl1 { get; set; }
        public string? PictureUrl2 { get; set; }
        public string? PictureUrl3 { get; set; }
    }
}
