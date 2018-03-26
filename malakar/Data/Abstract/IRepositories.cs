using malakar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace malakar.Data.Abstract
{
    public interface IUserRepository : IEntityBaseRepository<User>, IDisposable { }
    public interface ILayoutRepository : IEntityBaseRepository<Layout>, IDisposable { }

}