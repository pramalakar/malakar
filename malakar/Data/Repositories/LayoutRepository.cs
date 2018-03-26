using malakar.Data.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using malakar.Models;
using System.Linq.Expressions;

namespace malakar.Data.Repositories
{
    public class LayoutRepository : EntityBaseRepository<Layout>, ILayoutRepository
    {
        public LayoutRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}