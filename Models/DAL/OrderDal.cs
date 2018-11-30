using System;
using IrsMonkeyApi.Models.DB;
using IrsMonkeyApi.Models.Dto;
using Order = IrsMonkeyApi.Models.DB.Order;

namespace IrsMonkeyApi.Models.DAL
{
    public class OrderDal
    {
        private readonly IRSMonkeyContext _context;
        
        public OrderDal(IRSMonkeyContext context)
        {
            _context = context;
        }

        public Order SaveOrder(Order order)
        {
            try
            {
                _context.Order.Add(order);
                var newOrder = _context.SaveChanges();
                return newOrder > 0 ? order : null;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}