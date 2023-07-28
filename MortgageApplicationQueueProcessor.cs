using MortgageService.Domain;
using MortgageService.Service;
using System;

namespace MortgageService
{
    public class MortgageApplicationQueueProcessor
    {
        private readonly ICustomerRepository customerRepository;
        private readonly CustomerValidateService customerValidateService;

        public MortgageApplicationQueueProcessor(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
            this.customerValidateService = new CustomerValidateService();
        }

        public void ProcessRequest(int customerId, decimal amountRequested, Action<bool> responseHandler)
        {
            bool isRequestSuccessful = false;

            var customer = customerRepository.Get(customerId);

            customerValidateService.ValidateCustom(customer);

            if (customer.IsEligibleForMortgage(amountRequested))
            {
                customer.UpdateBalance(amountRequested);
                isRequestSuccessful = true;
            }

            responseHandler?.Invoke(isRequestSuccessful);
        }


    }
}
