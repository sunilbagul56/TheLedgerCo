using System;
using TheLedgerCompany.Contract;
using TheLedgerCompany.Model;

namespace TheLedgerCompany.Command
{
    public class PaymentCommand : ICommand
    {
        private IDataRepository _dataRepository;

        public PaymentCommand(IDataRepository dataRepository)
        {
            _dataRepository = dataRepository ?? throw new ArgumentNullException(nameof(dataRepository));
        }

        public void ExecuteAsync<TRequest>(TRequest request)
        {
            request.EnsureNotNull(nameof(PaymentCommandRequest));

            var paymentCommandRequest = request as PaymentCommandRequest;
            string identifier = _dataRepository.GetIdentifier(paymentCommandRequest.BankName, paymentCommandRequest.BorrowerName);
            var loan = _dataRepository.GetLoanInfo(identifier);

            if (loan != null)
                loan.AddLumSumEMI(paymentCommandRequest.EMINumber, paymentCommandRequest.LumSumAmount);
        }
    }
}
