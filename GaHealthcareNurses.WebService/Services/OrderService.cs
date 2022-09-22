using Contracts;
using Contracts.ServiceContracts;
using GaHealthcareNurses.Entity.Models;
using GaHealthcareNurses.Entity.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services
{
    public class OrderService : IOrderService
    {
        private IOrderRepository _orderRepository;
        private IEmployerService _employerService;

        #region Constructor for OrderService
        public OrderService(IOrderRepository orderRepository,IEmployerService employerService)
        {
            _employerService = employerService;
            _orderRepository = orderRepository;
        }
        #endregion

        #region Implementing Interface
        public async Task<IEnumerable<Order>> Get()
        {
            return await _orderRepository.Get();
        }

        public async Task<Order> GetById(string id)
        {
            return await _orderRepository.GetById(id);
        }

        public async Task<IEnumerable<Order>> GetByEmployerId(string id)
        {
            return await _orderRepository.GetByEmployerId(id);
        }

        public async Task<Order> Add(Order order)
        {
           return await _orderRepository.Add(order);
        }

        public async Task Delete(Order order)
        {
            await _orderRepository.Delete(order);
        }

        public async Task<Order> Update(Order order)
        {
           return await _orderRepository.Update(order);
        }

        public async Task<Order> AddSubscription(AddSubscriptionViewModel addSubscriptionViewModel)
        {
            var employerData = await _employerService.GetById(addSubscriptionViewModel.EmployerId);
            if (employerData != null)
            {
                employerData.SubscriptionId = addSubscriptionViewModel.PlanId;
            }

            Order order = new Order
            {
                OrderId = addSubscriptionViewModel.SubscriptionId,
                Status = addSubscriptionViewModel.Status,
                EmployerId = addSubscriptionViewModel.EmployerId
            };
           return await _orderRepository.Add(order);
        }

        public async Task UpdateSubscription(UpdateSubscriptionViewModel updateSubscriptionViewModel)
        {
            var order = await _orderRepository.GetById(updateSubscriptionViewModel.SubscriptionId);
            order.Status = updateSubscriptionViewModel.Status;
            order.Employer.IsSubscriptionActive = true;
            await _orderRepository.Update(order);
        }

        public async Task<IEnumerable<Order>> GetActiveOrder(string id)
        {
            return await _orderRepository.GetActiveOrderByEmployerId(id);
        }
        #endregion
    }
}
