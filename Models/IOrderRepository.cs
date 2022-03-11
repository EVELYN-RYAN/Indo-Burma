using System.Linq;
namespace Indo_Burma.Models
{
    public interface IOrderRepository
    {
        IQueryable<Order> Orders { get; }

        public void SaveOrder(Order order);
    }
}
