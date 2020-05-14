using Microsoft.Extensions.Options;
using System.Linq;
using Flurl.Http;
using System.Threading.Tasks;
using Burak.Boilerplate.Models.Responses;
using Burak.Boilerplate.Models.Requests;
using Burak.Boilerplate.ExternalServices.Interface;
using static Burak.Boilerplate.CommunicationEndpoints;
using Burak.Boilerplate.Utilities.Constants;

namespace Burak.Boilerplate.ExternalServices.Implementation
{
    public class ShopExternalService : IShopExternalService
    {
        private readonly IOptions<CommunicationEndPoints> _communicationEndPoints;

        public ShopExternalService(IOptions<CommunicationEndPoints> communicationEndPoints)
        {
            _communicationEndPoints = communicationEndPoints;
        }

        //public async Task<AddressResponse> CreateAddress(int brandId, int userId, AddressRequest addressRequest)
        //{
        //    var brandBaseUrl = _communicationEndPoints.Value.BrandBaseEndPoints.First(p => p.Id == brandId);

        //    var requestUrl = string.Format(_communicationEndPoints.Value.CustomerAddressEndPointTemplate, brandBaseUrl.BaseEndPoint, userId);
        //    var response = await requestUrl
        //        .WithHeader(AppConstants.AcceptedLanguageHeaderKey, AppConstants.DefaultCultureInfo.Name)
        //        .PostJsonAsync(addressRequest)
        //        .ReceiveJson<AddressRequest>();

        //    //TODO: Change here
        //    return new AddressResponse() { 
        //        Id = int.Parse(response.id)
        //    };
        //}

        
    }
}
