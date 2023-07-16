using CoreStartApp.Models.Entities;
using System;
using System.Threading.Tasks;

namespace CoreStartApp.DAL
{
    public interface IRequestRepository
    {
        Task AddRequest(Request request);
        Task<Request[]> GetRequests();
    }
}