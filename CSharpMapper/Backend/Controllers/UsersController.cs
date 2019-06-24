using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WebApi.Services;
using WebApi.Dtos;
using AutoMapper;
using System.IdentityModel.Tokens.Jwt;
using WebApi.Helpers;
using Microsoft.Extensions.Options;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using WebApi.Entities;
using Microsoft.AspNetCore.Authorization;

namespace WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private IUserService _userService;
        private IMapper _mapper;
        private readonly AppSettings _appSettings;

        public UsersController(
            IUserService userService,
            IMapper mapper,
            IOptions<AppSettings> appSettings)
        {
            _userService = userService;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("~/api/authenticate")]
        public IActionResult Authenticate([FromBody]UserDto userDto)
        {
            var user = _userService.Authenticate(userDto.Username, userDto.Password);

            if (user == null)
                return BadRequest("Username or password is incorrect");

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[] 
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            return Ok(new {
                Id = user.Id,
                Username = user.Username,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Token = tokenString
            });
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("~/api/register")]
        public IActionResult Register([FromBody]UserDto userDto)
        {
            var user = _mapper.Map<User>(userDto);

            try 
            {
                _userService.Create(user, userDto.Password);
                return Ok();
            } 
            catch(AppException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [AllowAnonymous]
        [HttpGet]     
        [Route("~/api/getall")]  
        public IActionResult GetAll()
        {
            var users =  _userService.GetAll();
            var userDtos = _mapper.Map<IList<UserDto>>(users);
            return Ok(userDtos);
        }

        [HttpGet("{id}")]
        [Route("~/api/getbyid/{id}")]  
        public IActionResult GetById(Guid id)
        {
            var user =  _userService.GetById(id);
            var userDto = _mapper.Map<UserDto>(user);
            return Ok(userDto);
        }

        [HttpPut("{id}")]
        [Route("~/api/update/{id}")]  
        public IActionResult Update(Guid id, [FromBody]UserDto userDto)
        {
            var user = _mapper.Map<User>(userDto);
            user.Id = id;

            try 
            {
                _userService.Update(user, userDto.Password);
                return Ok();
            } 
            catch(AppException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        [Route("~/api/delete/{id}")]  
        public IActionResult Delete(Guid id)
        {
            _userService.Delete(id);
            return Ok();
        }
    }
}
