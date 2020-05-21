using AutoMapper;
using Burak.Boilerplate.Business.Services.Interface;
using Burak.Boilerplate.ExternalServices.Interface;
using Burak.Boilerplate.Utilities.ValidationHelper.ValidatorResolver;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Burak.Boilerplate.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Authorize]
    [ApiController]
    [Route("api/store")]
    public class StoreApiController
    {
        private readonly ILogger<StoreApiController> _logger;
        private readonly IUserService _userService;
        private readonly IShopExternalService _shopExternalService;
        private readonly IValidatorResolver _validatorResolver;
        private readonly IMapper _mapper;

        public StoreApiController(ILogger<StoreApiController> logger,
            IUserService userService,
            IShopExternalService shopExternalService,
            IValidatorResolver validatorResolver,
            IMapper mapper
            )
        {
            _logger = logger;
            _userService = userService;
            _shopExternalService = shopExternalService;
            _validatorResolver = validatorResolver;
            _mapper = mapper;
        }

        //[HttpPost("")]
        //public async Task<UserResponse> PurchaseItem([FromBody] UserRequest userRequest)
        //{
        //    /* VALIDATE */
        //    var validator = _validatorResolver.Resolve<UserRequestValidator>();
        //    ValidationResult validationResult = validator.Validate(userRequest);
        //    if (!validationResult.IsValid)
        //    {
        //        throw new ValidationException(validationResult.ToString());
        //    }

        //    var user = _mapper.Map<User>(userRequest);

        //    var userResponse = _userService.CreateUser(user);

        //    var userResponseModel = _mapper.Map<UserResponse>(userResponse.Result);

        //    return userResponseModel;
        //}



    }
}
