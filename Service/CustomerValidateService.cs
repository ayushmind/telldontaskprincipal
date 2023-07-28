using MortgageService.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MortgageService.Service
{
    public class CustomerValidateService
    {
        private const string MessageInvalidCustomer = "Customer not found!";
        public void ValidateCustom(Customer customer)
        {
            if (customer == null)
            {
                throw new Exception(MessageInvalidCustomer);
            }
        }
    }
}
