using Application.Dtos;
using Application.Interfaces;
using AutoMapper;
using Domain.Models;
using Infrastructure.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace NinjaTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SegmentController : ControllerBase
    {
        private readonly ISegmentService segmentService;
        private readonly IMapper mapper;

        public SegmentController(ISegmentService segmentService,IMapper mapper)
        {
            this.segmentService = segmentService;
            this.mapper = mapper;
        }
        [HttpPost("Create_Segment")]
        public async Task<IActionResult> Create([FromBody]SegmentDto segmentDto)
        {
            var segmentModel = mapper.Map<Segment>(segmentDto);
            // Use Domain model to create
            await segmentService.Create(segmentModel);
            return Ok(segmentModel);
        }
        [HttpGet("GetAll_Segment")]
        public async Task<IActionResult> GetAll()
        {
          var segments =  await segmentService.GetAllSegment();
            //return dto
            return Ok(mapper.Map<List<SegmentDto>>(segments));
        }
    }
}
