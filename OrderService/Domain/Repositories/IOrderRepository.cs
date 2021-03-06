using Domain.Entities;

namespace Domain.Repositories
{
    public interface IOrderRepository : IDisposable
    {
        Task Add(Order order);
        Task<List<Order>> GetAll();
        Task<Order> GetById(Guid id);
        Task<bool> SaveChangesAsync();
    }
}
