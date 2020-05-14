using AutoMapper;
using Burak.Boilerplate.Models.Requests;
using Burak.Boilerplate.Models.Responses;
using Burak.Boilerplate.Data.EntityModels;

namespace Burak.Boilerplate.Business.Mappers
{
    public class UserMappingProfiles : Profile
    {
        public UserMappingProfiles()
        {
            /* Appointment Mappers */
            //CreateMap<AppointmentRequest, Data.EntityModels.Appointment>()
            //    .ForMember( x => x.Type, opt => opt.Ignore())
            //    .ForMember(x => x.Status, opt => opt.Ignore())
            //    .ForMember(x => x.Slot, opt => opt.Ignore());
            base.CreateMap<UserRequest, User>().ReverseMap();
            base.CreateMap<UserResponse, User>().ReverseMap();
            //CreateMap<Data.EntityModels.Appointment, AppointmentResponse>();
        }
    }
}