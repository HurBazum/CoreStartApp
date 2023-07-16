using CoreStartApp.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CoreStartApp.DAL
{
    public class RequestRepository : IRequestRepository
    {
        BlogContext _blogContext;
        public RequestRepository(BlogContext blogContext) 
        {
            _blogContext = blogContext;
        }
        public async Task AddRequest(Request request)
        {
            var entry = _blogContext.Entry(request);
            if (entry.State == EntityState.Detached)
            {
                await _blogContext.Requests.AddAsync(request);
            }
            await _blogContext.SaveChangesAsync();
        }
        public async Task<Request[]> GetRequests()
        {
            return await _blogContext.Requests.ToArrayAsync();
        }
    }
}