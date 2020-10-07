using System.Threading.Tasks;
using AutoMapper;
using Burak.Boilerplate.Business.Services.Interface;
using Burak.Boilerplate.Business.Validators;
using Burak.Boilerplate.Data.EntityModels;
using Burak.Boilerplate.ExternalServices.Interface;
using Burak.Boilerplate.Models.CustomExceptions;
using Burak.Boilerplate.Models.Requests;
using Burak.Boilerplate.Utilities;
using Burak.Boilerplate.Utilities.Constants;
using Burak.Boilerplate.Utilities.ValidationHelper.ValidatorResolver;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using ValidationException = FluentValidation.ValidationException;

namespace Burak.Boilerplate.Controllers
{
    [ApiController]
    [Route("api/item")]
    public class ItemApiController : ControllerBase
    {
        private readonly IStringLocalizer<ItemApiController> _localizer;
        private readonly ILogger<ItemApiController> _logger;
        private readonly IUserService _userService;
        private readonly IUserItemService _userItemService;
        private readonly IValidatorResolver _validatorResolver;
        private readonly IMapper _mapper;

        public ItemApiController(ILogger<ItemApiController> logger,
            IStringLocalizer<ItemApiController> localizer,
            IUserService userService,
            IUserItemService userItemService,
            IValidatorResolver validatorResolver,
            IMapper mapper
        )
        {
            _logger = logger;
            _userService = userService;
            _userItemService = userItemService;
            _validatorResolver = validatorResolver;
            _mapper = mapper;
            _localizer = localizer;
        }
        
        /*
         *Upgrade Item
         *Consume Item
         *Equip Item
         *Delete Item
         */
        
        [HttpPost("upgrade")]
        public async Task UpgradeItem([FromBody] UserItemRequest request)
        {
            /* VALIDATE */
            var validator = _validatorResolver.Resolve<UserItemRequestValidator>();
            ValidationResult validationResult = validator.Validate(request);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.ToString());
            }
            
            var user = await _userService.GetUserById(request.UserId);
            if (ControlUtil.isEmpty(user))  throw new NotFoundException(_localizer.GetString(LocaleResourceConstants.UserNotFound)); //TODO: Handle error logging and response model for client 
            
            var userItem = _mapper.Map<UserItem>(request);
            userItem.ItemLevel++;
            
            await _userItemService.UpdateUserItem(userItem);
        }
        
        [HttpPost("consume")]
        public async Task ConsumeItem([FromBody] UserItemRequest request)
        {
            /* VALIDATE */
            var validator = _validatorResolver.Resolve<UserItemRequestValidator>();
            ValidationResult validationResult = validator.Validate(request);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.ToString());
            }
            
            var user = await _userService.GetUserById(request.UserId);
            if (ControlUtil.isEmpty(user))  throw new NotFoundException(_localizer.GetString(LocaleResourceConstants.UserNotFound)); //TODO: Handle error logging and response model for client 
            
            var userItem = _mapper.Map<UserItem>(request);
            userItem.IsConsumed = true;
            
            await _userItemService.UpdateUserItem(userItem);
        }
        
        [HttpPost("equip")]
        public async Task EquipItem([FromBody] UserItemRequest request)
        {
            /* VALIDATE */
            var validator = _validatorResolver.Resolve<UserItemRequestValidator>();
            ValidationResult validationResult = validator.Validate(request);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.ToString());
            }
            
            var user = await _userService.GetUserById(request.UserId);
            if (ControlUtil.isEmpty(user))  throw new NotFoundException(_localizer.GetString(LocaleResourceConstants.UserNotFound)); //TODO: Handle error logging and response model for client 
            
            var userItem = _mapper.Map<UserItem>(request);
            userItem.IsEquipped = true;
            
            await _userItemService.UpdateUserItem(userItem);
        }
        
        [HttpDelete("")]
        public async Task DeleteItem([FromBody] UserItemRequest request)
        {
            /* VALIDATE */
            var validator = _validatorResolver.Resolve<UserItemRequestValidator>();
            ValidationResult validationResult = validator.Validate(request);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.ToString());
            }
            
            var user = await _userService.GetUserById(request.UserId);
            if (ControlUtil.isEmpty(user))  throw new NotFoundException(_localizer.GetString(LocaleResourceConstants.UserNotFound)); //TODO: Handle error logging and response model for client 
            
            var userItem = _mapper.Map<UserItem>(request);
            await _userItemService.DeleteUserItem(userItem);
        }
    }
}