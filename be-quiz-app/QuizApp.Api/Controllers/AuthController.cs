
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using QuizApp.Api.Resources;
using QuizApp.Core.Models.Auth;

namespace QuizApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly IMapper _mapper;
        public AuthController(
            IMapper mapper, 
            UserManager<User> userManager,
            RoleManager<Role> roleManager
            )
        {
            _mapper = mapper;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        [HttpPost("signup")]
        public async Task<IActionResult> SignUp(UserSignUpDTO userSignUpDTO)
        {
            var user = _mapper.Map<UserSignUpDTO, User>(userSignUpDTO);

            var userCreateResult = await _userManager.CreateAsync(user, userSignUpDTO.Password);

            if (userCreateResult.Succeeded)
            {
                return Created(string.Empty, string.Empty);
            }
            return Problem(userCreateResult.Errors.First().Description, null, 500);
        }

        [HttpPost("signin")]
        public async Task<IActionResult> SignIn(UserSignInDTO userSignInDTO)
        {
            var user = _userManager.Users.SingleOrDefault(u => u.UserName == userSignInDTO.Email);
            if (user == null)
            {
                return NotFound("User not found");
            }

            var signInResult = await _userManager.CheckPasswordAsync(user, userSignInDTO.Password);
            if (signInResult)
            {
                return Ok();
            }
            return BadRequest("Email or password incorrect.");
        }

        [HttpPost("Roles")]
        public async Task<IActionResult> CreateRole(string roleName)
        {
            if (string.IsNullOrWhiteSpace(roleName))
            {
                return BadRequest("Role name should be provided.");
            }

            var newRole = new Role
            {
                Name = roleName
            };

            var roleResult = await _roleManager.CreateAsync(newRole);

            if (roleResult.Succeeded)
            {
                return Ok();
            }
            return Problem(roleResult.Errors.First().Description, null, 500);
        }
        [HttpPost("User/{userEmail}/Role")]
        public async Task<IActionResult> AddUserToRole(string userEmail, [FromBody] string roleName)
        {
            var user = _userManager.Users.SingleOrDefault(u => u.UserName == userEmail);

            if(user == null)
            {
                return NotFound("User not found");
            }

            var result = await _userManager.AddToRoleAsync(user, roleName);
            if (result.Succeeded)
            {
                return Ok();
            }
            return Problem(result.Errors.First().Description, null, 500);
        }

    }
}
// Example token usage
// Authorization: Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIxMjM0NTY3ODkwIiwibmFtZSI6IkpvaG4gRG9lIiwiaWF0IjoxNTE2MjM5MDIyfQ.SflKxwRJSMeKKF2QT4fwpMeJf36POk6yJV_adQssw5c
