using Contracts;
using GaHealthcareNurses.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using GaHealthcareNurses.Entity.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class OrderRepository : IOrderRepository
    {
        private GaHealthcareNursesContext _gaHealthcareNursesContext;

        #region Contructor For OrderRepository
        public OrderRepository(GaHealthcareNursesContext context)
        {
            _gaHealthcareNursesContext = context;
        }
        #endregion

        #region Implementing Interface
        public async Task<Order> Add(Order order)
        {
            await _gaHealthcareNursesContext.Order.AddAsync(order);
            await _gaHealthcareNursesContext.SaveChangesAsync();
            return order;
        }

        public async Task Delete(Order order)
        {
            _gaHealthcareNursesContext.Order.Remove(order);
            await _gaHealthcareNursesContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Order>> Get()
        {
            return await _gaHealthcareNursesContext.Order.ToListAsync();
        }

        public async Task<Order> GetById(string id)
        {
            return await _gaHealthcareNursesContext.Order.Include(x=>x.Employer).Where(x => x.OrderId == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Order>> GetByEmployerId(string id)
        {
            return await _gaHealthcareNursesContext.Order.Include(x => x.Employer).Where(x => x.EmployerId == id).ToListAsync();
        }

        public async Task<Order> Update(Order order)
        {
            _gaHealthcareNursesContext.Order.Update(order);
            await _gaHealthcareNursesContext.SaveChangesAsync();
            return order;
        }

        public async Task<IEnumerable<Order>> GetActiveOrderByEmployerId(string id)
        {
            return await _gaHealthcareNursesContext.Order.Include(x => x.Employer).Where(x => x.EmployerId == id && x.Status == "ACTIVE").ToListAsync();
        }
        #endregion
    }
}
