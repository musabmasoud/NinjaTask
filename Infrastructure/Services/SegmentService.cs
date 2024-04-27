using Application.Interfaces;
using Domain.Models;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class SegmentService : ISegmentService
    {
        private readonly NinjaDbContext dbContext;

        public SegmentService(NinjaDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<Segment> Create(Segment segment)
        {
        await dbContext.AddAsync(segment);
        await dbContext.SaveChangesAsync();
            return segment;
        }

        public async Task<List<Segment>> GetAllSegment()
        {
            return await dbContext.Segments.ToListAsync();  
        }
    }
}
