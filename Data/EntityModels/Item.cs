﻿using Burak.Boilerplate.Models.BaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Burak.Boilerplate.Data.EntityModels
{
    public class Item : IEntity<int>
    {
        //TODO: Items should have types MarketItem, etc.
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? AndroidGameId{ get; set; }
        public string? AppleGameId{ get; set; }
        public bool? IsConsumable { get; set; }
        public bool? IsUpgradable { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
        public string? PictureUrl1{ get; set; }
        public string? PictureUrl2{ get; set; }
        public string? PictureUrl3{ get; set; }

        public DateTime? CreatedOnUtc { get; set; }
        public DateTime? UpdatedOnUtc { get; set; }

        public ICollection<UserItem> UserItems { get; set; }
    }
}
