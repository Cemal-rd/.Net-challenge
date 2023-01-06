using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace Infrastructure.Data
{
    public class OrderRepository : IOrderRepository
    {
        private readonly StoreContext _context;
        public OrderRepository(StoreContext context)
        {
            _context = context;
        }

        public void Add(Order order)
        {
            _context.Add(order);
        }

        public async Task<Order> GerOrderByIdAsnyc(int id)
        {
            return await _context.Orders.FindAsync(id);
        }

       

        public async Task<IReadOnlyList<Order>> GetOrdersAsync()
        {
            return await _context.Orders.ToListAsync();
        }

        public IQueryable<Order> Include(params Expression<Func<Order, object>>[] includes)
        {
           IIncludableQueryable<Order, object> query = null;

            if (includes.Length > 0)
            {
                query = _context.Orders.Include(includes[0]);
            }
            for (int queryIndex = 1; queryIndex < includes.Length; ++queryIndex)
            {
                query = query.Include(includes[queryIndex]);
            }

            return query == null ? _context.Orders : (IQueryable<Order>)query;
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync().ConfigureAwait(false) > 0;
        }
    }
}