using Microsoft.EntityFrameworkCore;

namespace SportsStore.Models
{
    public class EFOrderRepository : IOrderRepository
    {
        private StoreDbContext _context;
        public IQueryable<Order> Orders => _context.Orders
                                            .Include(o => o.cartLines)
                                            .ThenInclude(c => c.Product);

        public EFOrderRepository(StoreDbContext context) 
        {
            _context = context;
        }

        public void SaveOrder(Order order)
        {
            _context.AttachRange(order.cartLines.Select(l => l.Product));
            if (order.OrderID == 0)
            {
                _context.Orders.Add(order);
            }
            _context.SaveChanges();
        }
    }
}
