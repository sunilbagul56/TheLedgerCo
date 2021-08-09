using System;

namespace TheLedgerCompany.Model
{
    public class LoadCommandRequest
    {
        public LoadCommandRequest(string bankName, string borrowerName, int principalAmount, int noOfYears, int rateOfInterest)
        {
            BankName = bankName ?? throw new ArgumentNullException(nameof(bankName));
            BorrowerName = borrowerName ?? throw new ArgumentNullException(nameof(borrowerName));
            PrincipalAmount = principalAmount;
            NoOfYears = noOfYears;
            RateOfInterest = rateOfInterest;
        }

        //LOAN BANK_NAME BORROWER_NAME PRINCIPAL NO_OF_YEARS RATE_OF_INTEREST
        public string BankName { get; set; }
        public string BorrowerName { get; set; }
        public int PrincipalAmount { get; set; }
        public int NoOfYears { get; set; }
        public int RateOfInterest { get; set; }
    }
}
