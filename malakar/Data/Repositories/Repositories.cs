using malakar.Data.Abstract;
using malakar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace malakar.Data.Repositories
{
    public class UserRepository : EntityBaseRepository<User>, IUserRepository
    {
        public UserRepository(ApplicationDbContext context) : base(context) { }
    }
}