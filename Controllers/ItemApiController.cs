using System.Threading.Tasks;
using AutoMapper;
using Burak.Boilerplate.Business.Services.Interface;
using Burak.Boilerplate.Business.Validators;
using Burak.Boilerplate.ExternalServices.Interface;
using Burak.Boilerplate.Models.Requests;
using Burak.Boilerplate.Utilities.ValidationHelper.ValidatorResolver;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;

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
        private readonly IShopExternalService _shopExternalService;
        private readonly IValidatorResolver _validatorResolver;
        private readonly IMapper _mapper;

        public ItemApiController(ILogger<ItemApiController> logger,
            IStringLocalizer<ItemApiController> localizer,
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
            
            
        }
    }
}