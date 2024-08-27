using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Talabat.Rev.CoreLayer;
using Talabat.Rev.CoreLayer.Entites.IdentityData;
using Talabat.Rev.CoreLayer.ServiceLayer.Contract;
using Talabat.Rev.Dto;
using Talabat.Rev.Errors;
using Talabat.Rev.Extentions;

namespace Talabat.Rev.Controllers
{
    
    public class AccountController :BaseApiController
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IAuthServices _authServices;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public AccountController(
            UserManager<AppUser> userManager
            ,SignInManager<AppUser> signInManager,
            IAuthServices authServices,
            IMapper mapper,
            IUnitOfWork unitOfWork)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _authServices = authServices;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }


        [HttpPost("Login")] //Get : Api/Account/login
        public async Task<ActionResult<UserDto>> Login(LoginDto dto) 
        {
            var user = await _userManager.FindByEmailAsync(dto.Email);
            if (user is null)
                return Unauthorized(new ApiResponse(401));
            var chackPassword = await _signInManager.CheckPasswordSignInAsync(user, dto.Password,false);
            if(chackPassword.Succeeded)
                return Ok(new UserDto() {Email= user.Email , DisplayName = user.DisplayName, Token = await _authServices.GenerateTokenAsync(user,_userManager) });
            return BadRequest(new ApiResponse(400));
        }

         
        [HttpPost("Register")]
        public async Task<ActionResult> Register(RegisterDto dto) 
        {
            if (checkEmailExist(dto.Email).Result.Value)
                return BadRequest(new ApiValidationErrorResponse() { Errors = new string[] { "User Email  is Exsist" } });

            if (_userManager.FindByNameAsync(dto.Username).Result is  null)
            {
                var user = new AppUser()
                {
                    Email = dto.Email,
                    DisplayName = dto.Displayname,
                    UserName = dto.Username,
                    PhoneNumber = dto.phonenumber,
                };

                var result = await _userManager.CreateAsync(user, dto.Password);
                if (!result.Succeeded)
                    return BadRequest(new ApiResponse(400));
                return Ok(new UserDto() { Email = user.Email, DisplayName = user.DisplayName, Token = await _authServices.GenerateTokenAsync(user, _userManager) });
            }
            return BadRequest(new ApiValidationErrorResponse() { Errors = new string[] {"User Name is Exsist"} });
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("Address")]
        public async Task<ActionResult<AddressDto>> GetUserAdderess()
        {
            var user =await  _userManager.FindUserAddressByEmail(User);

            var address = _mapper.Map<Address, AddressDto>(user.Address);

            return Ok(address);
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPut("Address")]
        public async Task<ActionResult<AddressDto>> UpdateUserAddress(AddressDto dto)
        {

            var user = await _userManager.FindUserAddressByEmail(User);

            var address = _mapper.Map<AddressDto, Address>(dto);

            address.Id = user.Address.Id;

            user.Address = address; // change Stata Obj

           var Result = await _userManager.UpdateAsync(user);

            if (!Result.Succeeded)
                return BadRequest(new ApiResponse(400));
            return Ok(dto);
        }


        [HttpGet("CheckEmail")]
        public async Task<ActionResult<bool>> checkEmailExist(string email) 
        {
            return await _userManager.FindByEmailAsync(email) is not null;
        }
    }
}
