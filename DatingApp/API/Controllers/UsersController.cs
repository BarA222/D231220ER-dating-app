using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    public class UsersController : BaseApiConrroller
    {
        private readonly DataContext _context;
        public UsersController(DataContext context) 
        {
          _context= context;
        }      
       [HttpGet]
       public async Task<ActionResult<IEnumerable<AppUser>>> GetUsersAsync()
       {
           var users = await _context.Users.ToListAsync();
           return users;
       }

        //Get user by specific id --> api/users/3
       [HttpGet("{id}")]
          public async Task<ActionResult<AppUser>> GetUserAsync(int id)
       {
           var user = await _context.Users.FindAsync(id);
           return user;
       }
    }
}