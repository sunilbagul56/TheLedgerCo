using System;
using System.Collections.Generic;
using TheLedgerCompany.Contract;
using TheLedgerCompany.Model;

namespace TheLedgerCompany.Command
{
    public class BalanceCommand : ICommand
    {
        private IDataRepository _dataRepository;

        public BalanceCommand(IDataRepository dataRepository)
        {
            _dataRepository = dataRepository ?? throw new ArgumentNullException(nameof(dataRepository));
        }

        public void ExecuteAsync<TRequest>(TRequest request)
        {
            request.EnsureNotNull(nameof(BalanceCommandRequest));
            var balanceCommandRequest = request as BalanceCommandRequest;
            string identifier = _dataRepository.GetIdentifier(balanceCommandRequest.BankName, balanceCommandRequest.BorrowerName);
            var loan = _dataRepository.GetLoanInfo(identifier);

            if (loan != null)
                CalculateLoanBalance(loan, balanceCommandRequest.EMINumber);
        }

        private void CalculateLoanBalance(Loan loan, int eMINumber)
        {
            var totalMonths = loan.Tenure * 12;
            var interestAmt = (loan.PrincipalAmount * loan.RateOfInterest * loan.Tenure) / 100;
            decimal totalAmtPayable = loan.PrincipalAmount + interestAmt;
            var monthlyEMI = (int)Math.Ceiling(totalAmtPayable / totalMonths);
            var totalAmtPaid = eMINumber * monthlyEMI;
            var lumSumPaid = loan.LumSumPaidEMI;

            foreach (KeyValuePair<int, int> lumSum in lumSumPaid)
            {
                if (lumSum.Key <= eMINumber)
                    totalAmtPaid = totalAmtPaid + lumSum.Value;
            }

            decimal amountRemaining = (int)Math.Ceiling(totalAmtPayable - totalAmtPaid);
            var newTenureInMonths = (int)Math.Ceiling(amountRemaining / monthlyEMI);
            var totalAmtPayableInt = (int)Math.Ceiling(totalAmtPayable);

            if (totalAmtPaid > totalAmtPayableInt)
                totalAmtPaid = totalAmtPayableInt;

            PrintOutput(loan.BankName, loan.BorrowerName, totalAmtPaid, newTenureInMonths);
        }

        private void PrintOutput(string bankName, string borrowerName, int totalAmtPaid, int newTenureInMonths)
        {
            Console.WriteLine($"{bankName} \t\t {borrowerName} \t\t {totalAmtPaid} \t\t\t {newTenureInMonths}");
            Console.WriteLine("------------------------------------------------------------------------------");
        }
    }
}
