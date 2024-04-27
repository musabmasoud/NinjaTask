using Application.Dtos;
using Application.Interfaces;
using AutoMapper;
using Domain.Models;
using Infrastructure.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.Intrinsics.X86;

namespace NinjaTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;
        private readonly IMapper mapper;
        private readonly SnapchatService snapchatService;

        public UserController(IUserService userService,IMapper mapper,SnapchatService snapchatService)
        {
            this.userService = userService;
            this.mapper = mapper;
            this.snapchatService = snapchatService;
        }
        [HttpPost("Create_User")]
        public async Task<IActionResult> Create([FromBody] UserDto userDto)
        {
            //Map DTO to Domain Model
            var userModel=mapper.Map<Users>(userDto);
            // Use Domain model to create
            await userService.Create(userModel);
            return Ok(userModel);
        }
        [HttpGet("GetAll_User")]
        public async Task<IActionResult> GetAll()
        {

            var userModel = await userService.GetAllUsers();
            //return dto
            return Ok(mapper.Map<List<UserDto>>(userModel));
        }
       
    }
}
