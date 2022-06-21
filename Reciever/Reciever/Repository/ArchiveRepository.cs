using Microsoft.EntityFrameworkCore;
using Reciever.DbContexts;
using Reciever.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Reciever.Repository
{
    public class ArchiveRepository : IArchiveRepository
    {
        private IApplicationDbContext _dbcontext;
        public ArchiveRepository(IApplicationDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public async Task Create(List<Archive> archives)
        {
            foreach (var archive in archives)
            {
                _dbcontext.Archives.Add(archive);
            }

            await _dbcontext.SaveChanges();
            //return archives..Id;
        }
        public async Task<List<Archive>> GetAll()
        {
            var archives = await _dbcontext.Archives.ToListAsync<Archive>();
            return archives;
        }
       
    }
}
