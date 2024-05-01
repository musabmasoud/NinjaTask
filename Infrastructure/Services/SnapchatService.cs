using Application.Interfaces.Users;
using Domain.Models;
using Infrastructure.Data;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class SnapchatService:ISnapchatService
    {
        private readonly NinjaDbContext dbContext;

        public SnapchatService(NinjaDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<UserSegment> PushUser(UserSegment userSegment)
        {
            await dbContext.AddAsync(userSegment);
            await dbContext.SaveChangesAsync();
            return userSegment;
        }
    }
}

