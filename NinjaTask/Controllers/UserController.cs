using Application.Dtos;
using Application.Interfaces;
using Application.Interfaces.Users;
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
        private readonly ISnapchatService snapchatService;

        public UserController(IUserService userService,IMapper mapper,ISnapchatService snapchatService)
        {
            this.userService = userService;
            this.mapper = mapper;
            this.snapchatService = snapchatService;
        }
        [HttpPost("Create_User")]
        public async Task<IActionResult> Create([FromBody] UserDto userDto)
        {
            //Map DTO to Domain Model
            var userModel=mapper.Map<User>(userDto);
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
        [HttpPost("Push_User")]
        public async Task<IActionResult> PushUser([FromBody] UserSegmentDto userSegmentDto)
        {
            //Map DTO to Domain Model
            var userSegmentModel = mapper.Map<UserSegment>(userSegmentDto);
            // Use Domain model to create
            await snapchatService.PushUser(userSegmentModel);
            return Ok(userSegmentModel);
        }
    }
}
