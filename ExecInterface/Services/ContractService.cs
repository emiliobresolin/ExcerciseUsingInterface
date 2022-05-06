using ExecInterface.Entities;
using System;

namespace ExecInterface.Services
{
    class ContractService
    {
        private IOnlinePaymentService _onlinePaymentService;
        public ContractService(IOnlinePaymentService onlinePaymentService)
        {
            _onlinePaymentService = onlinePaymentService;
        }
        public void ProcessContract(Contract contract, int months)
        {
            double quota = contract.TotalValue / months;
            for (int i = 0; i <= months; i++)
            {
                DateTime date = contract.Date.AddMonths(i);
                double updateQuota = quota + _onlinePaymentService.Interest(quota, i);
                double fullQuota = updateQuota + _onlinePaymentService.PaymentFee(updateQuota);
                contract.AddInstallment(new Installment(date, fullQuota));
            }
        }
    }
}
