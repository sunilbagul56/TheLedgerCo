using System;

namespace TheLedgerCompany.Model
{
    public class BalanceCommandRequest
    {
        public BalanceCommandRequest(string bankName, string borrowerName, int eMINumber)
        {
            BankName = bankName ?? throw new ArgumentNullException(nameof(bankName));
            BorrowerName = borrowerName ?? throw new ArgumentNullException(nameof(borrowerName));
            EMINumber = eMINumber;
        }

        //BALANCE BANK_NAME BORROWER_NAME EMI_NO

        public string BankName { get; set; }
        public string BorrowerName { get; set; }
        public int EMINumber { get; set; }
    }
}
