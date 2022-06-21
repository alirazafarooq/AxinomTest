using Microsoft.AspNetCore.Http;
using System.Net;

namespace Sender.Services
{
    public interface IExtractZipService
    {
        HttpStatusCode zipUpload(IFormFile file);
    }
}
