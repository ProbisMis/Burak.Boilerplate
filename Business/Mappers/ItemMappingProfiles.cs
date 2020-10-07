using AutoMapper;
using Burak.Boilerplate.Data.EntityModels;
using Burak.Boilerplate.Models.Requests;
using Burak.Boilerplate.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Burak.Boilerplate.Business.Mappers
{
    public class ItemMappingProfiles : Profile
    {
        public ItemMappingProfiles()
        {
            /* Appointment Mappers */
            //CreateMap<AppointmentRequest, Data.EntityModels.Appointment>()
            //    .ForMember( x => x.Type, opt => opt.Ignore())
            //    .ForMember(x => x.Status, opt => opt.Ignore())
            //    .ForMember(x => x.Slot, opt => opt.Ignore());
            base.CreateMap<ItemRequest, Item>().ReverseMap();
          
            base.CreateMap<ItemResponse, Item>().ReverseMap();
            //CreateMap<Data.EntityModels.Appointment, AppointmentResponse>();
        }
    }
}
