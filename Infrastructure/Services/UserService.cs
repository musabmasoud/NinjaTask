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
    public class UserService : IUserService
    {
        private readonly NinjaDbContext dbContext;

        public UserService(NinjaDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<Users> Create(Users users)
        {
           await dbContext.AddAsync(users);
            await dbContext.SaveChangesAsync();
            return users;
        }

        public async Task<List<Users>> GetAllUsers()
        {
            return await dbContext.Users.ToListAsync();
        }

    }
}
