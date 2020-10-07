using System.Threading.Tasks;
using AutoMapper;
using Burak.Boilerplate.Business.Services.Interface;
using Burak.Boilerplate.Business.Validators;
using Burak.Boilerplate.Data.EntityModels;
using Burak.Boilerplate.ExternalServices.Interface;
using Burak.Boilerplate.Models.Requests;
using Burak.Boilerplate.Models.Responses;
using Burak.Boilerplate.Utilities.Constants;
using Burak.Boilerplate.Utilities.ValidationHelper.ValidatorResolver;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;

namespace Burak.Boilerplate.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/user")]
    public class UserApiController : ControllerBase
    {
        private readonly IStringLocalizer<UserApiController> _localizer;
        private readonly ILogger<UserApiController> _logger;
        private readonly IUserService _userService;
        private readonly IShopExternalService _shopExternalService;
        private readonly IValidatorResolver _validatorResolver;
        private readonly IMapper _mapper;

        public UserApiController(ILogger<UserApiController> logger,
            IStringLocalizer<UserApiController> localizer, 
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
            _localizer = localizer;
        }
        
        [AllowAnonymous]
        [HttpPost("testLocale")]
        public string TestLocale()
        {
            return _localizer.GetString(LocaleResourceConstants.UserNotFound);
        }
        
        #region Authorization

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public async Task<UserResponse> Authenticate([FromBody]LoginRequest userRequest)
        {
                var user = await _userService.Authenticate(userRequest.Username, userRequest.Password);

                return _mapper.Map<UserResponse>(user);
        }

        #endregion

        #region User

        //[HttpGet("all")]
        //public async Task<List<UserResponse>> GetAll()
        //{
        //    var users = _userService.GetAll();

        //    return users;
        //}

    
    /// <summary>
    /// Creates user
    /// </summary>
    /// <param name="userRequest"></param>
    /// <returns></returns>
    [HttpPost("")]
        public async Task<UserResponse> CreateUser([FromBody] UserRequest userRequest)
        {
            /* VALIDATE */
            var validator = _validatorResolver.Resolve<UserRequestValidator>();
            ValidationResult validationResult = validator.Validate(userRequest);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.ToString());
            }

            var user = _mapper.Map<User>(userRequest);

            var userResponse = _userService.CreateUser(user);

            var userResponseModel = _mapper.Map<UserResponse>(userResponse.Result);

            return userResponseModel;
        }

        /// <summary>
        /// Updates  user
        /// </summary>
        /// <param name="userRequest"></param>
        /// <returns></returns>
        [HttpPut("")]
        public async Task<UserResponse> UpdateUser([FromBody] UserRequest userRequest)
        {
            /* VALIDATE */
            var validator = _validatorResolver.Resolve<UserRequestValidator>();
            ValidationResult validationResult = validator.Validate(userRequest);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.ToString());
            }

            var user = _mapper.Map<User>(userRequest);

            var userResponse = _userService.UpdateUser(user);

            var userResponseModel = _mapper.Map<UserResponse>(userResponse.Result);

            return userResponseModel;
        }


        /// <summary>
        /// Deletes  user
        /// </summary>
        /// <param name="userRequest"></param>
        /// <returns></returns>
        [HttpDelete("{userId}")]
        public async Task<UserResponse> DeleteUser([FromRoute] int userId)
        {
            if (userId == 0)
                return null;

            var user = _userService.GetUserById(userId);

            var userResponse = _userService.DeleteUser(user.Result);

            var userResponseModel = _mapper.Map<UserResponse>(userResponse.Result);

            return userResponseModel;
        }

        /// <summary>
        /// Gets  user
        /// </summary>
        /// <param name="userRequest"></param>
        /// <returns></returns>
        [HttpGet("{userId}")]
        public async Task<UserResponse> GetUser([FromRoute] int userId)
        {
            if (userId == 0)
                return null;

            var user = _userService.GetUserById(userId);

            var userResponseModel = _mapper.Map<UserResponse>(user.Result);

            return userResponseModel;
        }

        #endregion
    } 
}
