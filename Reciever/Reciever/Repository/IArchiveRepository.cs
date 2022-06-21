using Reciever.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Reciever.Repository
{
    public interface IArchiveRepository
    {
            Task Create(List<Archive> archive);
            Task<List<Archive>> GetAll(); 
    }
}
