using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using System.Linq.Expressions;

namespace Core.Interfaces
{
    public interface IOrderRepository
    {
        Task<Order> GerOrderByIdAsnyc(int id);
        Task<IReadOnlyList<Order>> GetOrdersAsync();
        IQueryable<Order> Include(params Expression<Func<Order, object>>[] includes);
    
        Task<bool> SaveChangesAsync();
        void Add(Order order);
    }
}