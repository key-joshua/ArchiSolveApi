using Data.Repositories;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Services;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WebFramework.Api;
using Microsoft.AspNetCore.Identity;
using MyApi.Models;
using Microsoft.AspNetCore.Authorization;
using System;
using Common.Exceptions;
using Microsoft.AspNetCore.Cors;
using WebFrameWork.Api;
using ArchiSolveApi.Models;
using AutoMapper.QueryableExtensions;
using AutoMapper;

namespace ArchiSolveApi.Controllers.v1
{
    [EnableCors("_myAllowSpecificOrigins")]
    public class UsersController : BaseController
    {
        private readonly IUserRepository userRepository;
        private readonly ILogger<UsersController> logger;
        private readonly IJwtService jwtService;
        private readonly UserManager<User> userManager;
        private readonly RoleManager<Role> roleManager;
        private readonly SignInManager<User> signInManager;
        private readonly IMapper _mapper;

        public UsersController(IUserRepository userRepository, ILogger<UsersController> logger, IJwtService jwtService,
            UserManager<User> userManager, RoleManager<Role> roleManager, SignInManager<User> signInManager, IMapper mapper)
        {
            this.userRepository = userRepository;
            this.logger = logger;
            this.jwtService = jwtService;
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.signInManager = signInManager;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<ActionResult<List<User>>> Get(CancellationToken cancellationToken)
        {
            //var userName = HttpContext.User.Identity.GetUserName();
            //userName = HttpContext.User.Identity.Name;
            //var userId = HttpContext.User.Identity.GetUserId();
            //var userIdInt = HttpContext.User.Identity.GetUserId<int>();
            //var phone = HttpContext.User.Identity.FindFirstValue(ClaimTypes.MobilePhone);
            //var role = HttpContext.User.Identity.FindFirstValue(ClaimTypes.Role);

            var users = await userRepository.TableNoTracking.ToListAsync(cancellationToken);
            return Ok(users);
        }

        [HttpGet("single/{id:int}")]
        public async Task<ApiResult<User>> Single(int id, CancellationToken cancellationToken)
        {

            var user = await userRepository.GetByIdAsync(cancellationToken, id);
            if (user == null)
                return NotFound();

            await userManager.UpdateSecurityStampAsync(user);

            return user;
           
        }



        [HttpPost("create")]
        public async Task<ApiResult<User>> Create([FromBody] UserDto dto, CancellationToken cancellationToken)
        {
            if (Request.Headers.TryGetValue("Authorization", out var headerValue))
            {
                var user = new User();
                user.UserName = dto.UserName;
                user.IsActive = false;
                user.UserType = UserType.Admin;
                user.EmailConfirmed = false;
                user.PhoneNumberConfirmed = false;
                user.TwoFactorEnabled = false;
                user.LockoutEnabled = false;
                user.AccessFailedCount = 0;
                user.Email = dto.Email;

                await userRepository.AddAsync(user, dto.Password, cancellationToken);


                var user2 = await userRepository.GetByIdAsync(cancellationToken, dto.Id);
                return user2;
            }
            else
            {
                throw new BadRequestException("Access denied;");
            }
        }


        /// <summary>
        /// This method generate JWT Token
        /// </summary>
        /// <param name="tokenRequest">The information of token request</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPost("Login")]
        [AllowAnonymous]
        public virtual async Task<ActionResult> Login([FromBody] TokenRequest tokenRequest, CancellationToken cancellationToken)
        {
            //if (!tokenRequest.grant_type.Equals("password", StringComparison.OrdinalIgnoreCase))
            //    throw new Exception("OAuth flow is not password.");

            var user = await userRepository.GetByUserAndPass(tokenRequest.username, tokenRequest.password, cancellationToken);
            if (user == null)
                throw new BadRequestException("Username or Password is wrong");

            //var isPasswordValid = await userManager.CheckPasswordAsync(user, tokenRequest.password);
            //if (!isPasswordValid)
            //    throw new BadRequestException("نام کاربری یا رمز عبور اشتباه است");


            //if (user == null)
            //    throw new BadRequestException("نام کاربری یا رمز عبور اشتباه است");


            var jwt = await jwtService.GenerateAsync(user);
            var a = new JsonResult(jwt);
            var b = a;
            return b;
        }


        [HttpPost("edit")]
        public async Task<ApiResult<User>> Update([FromBody] UserDto dto, CancellationToken cancellationToken)
        {
            var oldUser = await userManager.FindByNameAsync(dto.UserName);
            if (oldUser != null)
            {
                if (oldUser.Id != dto.Id)
                {
                    return BadRequest("A user with the same username exist.");
                }
            }

            var model = await userRepository.GetByIdAsync(cancellationToken, dto.Id);

            model.UserName = dto.UserName;
            model.PasswordHash = dto.Password;
            model.Email = dto.Email;
            model.UserType = UserType.Admin;
            model.PhoneNumberConfirmed = false;
            model.TwoFactorEnabled = false;
            model.LockoutEnabled = false;
            model.IsActive = dto.IsActive;

            await userRepository.UpdateAsync(model, cancellationToken);

            var user = await userRepository.GetByIdAsync(cancellationToken, dto.Id);
            return user;
        }

        [HttpDelete("delete/{userid:int}")]
        public async Task<ApiResult> Delete(int userId, CancellationToken cancellationToken)
        {
            var model = await userRepository.GetByIdAsync(cancellationToken, userId);
            await userRepository.DeleteAsync(model, cancellationToken);

            return Ok();
        }

        //[HttpGet("{id:int}")]
        //public async Task<ApiResult<User>> Get(int id, CancellationToken cancellationToken)
        //{
        //    var user2 = await userManager.FindByIdAsync(id.ToString());
        //    var role = await roleManager.FindByNameAsync("Admin");

        //    var user = await userRepository.GetByIdAsync(cancellationToken, id);
        //    if (user == null)
        //        return NotFound();

        //    await userManager.UpdateSecurityStampAsync(user);
        //    //await userRepository.UpdateSecuirtyStampAsync(user, cancellationToken);

        //    return user;
        //}

        //[HttpGet("[action]")]
        //public async Task<string> Token(string username, string password, CancellationToken cancellationToken)
        //{
        //    //var user = await userRepository.GetByUserAndPass(username, password, cancellationToken);
        //    var user = await userManager.FindByNameAsync(username);
        //    if (user == null)
        //        throw new BadRequestException("نام کاربری یا رمز عبور اشتباه است");
        //    var isPasswordValid = await userManager.CheckPasswordAsync(user, password);
        //    if (!isPasswordValid)
        //        throw new BadRequestException("نام کاربری یا رمز عبور اشتباه است");


        //    //if (user == null)
        //    //    throw new BadRequestException("نام کاربری یا رمز عبور اشتباه است");

        //    var jwt = await jwtService.GenerateAsync(user);
        //    return jwt;
        //}

        //[HttpPost]
        //public async Task<ApiResult<User>> Create(UserDto userDto, CancellationToken cancellationToken)
        //{
        //    logger.LogError("متد Create فراخوانی شد");
        //    //HttpContext.RiseError(new Exception("متد Create فراخوانی شد"));

        //    //var exists = await userRepository.TableNoTracking.AnyAsync(p => p.UserName == userDto.UserName);
        //    //if (exists)
        //    //    return BadRequest("نام کاربری تکراری است");


        //    var user = new User
        //    {
        //        UserName = userDto.UserName,
        //        UserType = UserType.Admin,
        //        IsActive = true,
        //        PhoneNumberConfirmed = false,
        //        TwoFactorEnabled = false,
        //        LockoutEnabled = false
        //    };
        //    var result = await userManager.CreateAsync(user, userDto.Password);

        //    var result2 = await roleManager.CreateAsync(new Role
        //    {
        //        Name = "Admin",
        //        Description = "admin role"
        //    });

        //    var result3 = await userManager.AddToRoleAsync(user, "Admin");

        //    //await userRepository.AddAsync(user, userDto.Password, cancellationToken);
        //    return user;
        //}

        //[HttpPut]
        //public async Task<ApiResult> Update(int id, User user, CancellationToken cancellationToken)
        //{
        //    var updateUser = await userRepository.GetByIdAsync(cancellationToken, id);



        //    updateUser.UserName = user.UserName;
        //    updateUser.PasswordHash = user.PasswordHash;
        //    updateUser.UserType = UserType.Admin;
        //    updateUser.PhoneNumberConfirmed = false;
        //    updateUser.TwoFactorEnabled = false;
        //    updateUser.LockoutEnabled = false;
        //    updateUser.IsActive = user.IsActive;
        //    updateUser.LastLoginDate = user.LastLoginDate;

        //    await userRepository.UpdateAsync(updateUser, cancellationToken);

        //    return Ok();
        //}

        //[HttpDelete]
        //public async Task<ApiResult> Delete(int id, CancellationToken cancellationToken)
        //{
        //    var user = await userRepository.GetByIdAsync(cancellationToken, id);
        //    await userRepository.DeleteAsync(user, cancellationToken);

        //    return Ok();
        //}
    }
}
