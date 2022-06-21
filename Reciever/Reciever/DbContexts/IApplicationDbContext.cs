using Microsoft.EntityFrameworkCore;
using Reciever.Models;
using System.Collections.Generic;

using System.Threading.Tasks;

namespace Reciever.DbContexts
{
    public interface IApplicationDbContext
    {
        DbSet<Archive> Archives { get; set; }
        Task<int> SaveChanges();
    }
}
