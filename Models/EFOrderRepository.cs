using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Indo_Burma.Models
{
    public class EFOrderRepository : IOrderRepository
    {
        private BookstoreContext context;

        public EFOrderRepository(BookstoreContext temp)
        {
            context = temp;
        }

        public IQueryable<Order> Orders =>
            context.Orders.Include(x => x.Lines).ThenInclude(x => x.Book);

        //IQueryable<Order> IOrderRepository.Orders { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void SaveOrder(Order order)
        {
            context.AttachRange(order.Lines.Select(x => x.Book));

            if (order.OrderNumber == 0)
            {
                context.Orders.Add(order);
            }

            context.SaveChanges();
        }
    }
}
