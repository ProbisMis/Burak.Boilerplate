using AutoMapper;
using Burak.Boilerplate.Business.Services.Interface;
using Burak.Boilerplate.Business.Validators;
using Burak.Boilerplate.Data.EntityModels;
using Burak.Boilerplate.ExternalServices.Interface;
using Burak.Boilerplate.Models.CustomExceptions;
using Burak.Boilerplate.Models.Requests;
using Burak.Boilerplate.Models.Responses;
using Burak.Boilerplate.Utilities.ValidationHelper.ValidatorResolver;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Burak.Boilerplate.Utilities.Constants;
using Microsoft.Extensions.Localization;

namespace Burak.Boilerplate.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Authorize]
    [ApiController]
    [Route("api/store")]
    public class StoreApiController : ControllerBase
    {
        private readonly IStringLocalizer<UserApiController> _localizer;
        private readonly ILogger<StoreApiController> _logger;
        private readonly IUserService _userService;
        private readonly IUserItemService _userItemService;
        private readonly IShopExternalService _shopExternalService;
        private readonly IValidatorResolver _validatorResolver;
        private readonly IMapper _mapper;

        public StoreApiController(ILogger<StoreApiController> logger,
            IStringLocalizer<UserApiController> localizer,
            IUserService userService,
            IUserItemService userItemService,
            IShopExternalService shopExternalService,
            IValidatorResolver validatorResolver,
            IMapper mapper
            )
        {
            _logger = logger;
            _userService = userService;
            _userItemService = userItemService;
            _shopExternalService = shopExternalService;
            _validatorResolver = validatorResolver;
            _mapper = mapper;
            _localizer = localizer;
        }

        /// <summary>
        /// Partially Implemented - Purchase a set of item
        /// </summary>
        /// <param name="userRequest"></param>
        /// <returns></returns>
        [HttpPost("purchase")]
        public async Task<UserResponse> PurchaseItem([FromBody] PurchaseRequestModel purchaseRequest)
        {
            /*
               FLOW:
                    1. User'ı ve Item'ı göndermeli. 
                    2. User var mı?
                    3. Item var mı?
                    4. Ödeme yöntemi nedir? Ona göre hareket edilecek. Kredikartı veya oyun parası. (Bunun için yeni bir modele ihtiyaç var)
                    5. Ödeme valid ise UserItem tablosuna listedeki Item'lar eklenecek. Ve yeni Item'listesi  ve User değerleri dönmeli. 
             */
            /* VALIDATE */
            var validator = _validatorResolver.Resolve<PurchaseRequestValidator>();
            var validationResult = validator.Validate(purchaseRequest);
            if (!validationResult.IsValid)
            {
                throw new FluentValidation.ValidationException(validationResult.ToString());
            }

            foreach (var item in purchaseRequest.Items)
            {
                var purchaseResponse = await _userItemService.CreateUserItem(item);
            }

            var foundUser = await _userService.GetUserById(purchaseRequest.CustomerId);
            if (foundUser == null) throw new NotFoundException(_localizer.GetString(LocaleResourceConstants.UserNotFound)); //TODO: Handle error logging and response model for client 

            return _mapper.Map<UserResponse>(foundUser);
        }

    }
}
