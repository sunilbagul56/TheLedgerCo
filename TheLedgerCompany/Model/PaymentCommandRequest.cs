using System;

namespace TheLedgerCompany.Model
{
    public class PaymentCommandRequest
    {
        public PaymentCommandRequest(string bankName, string borrowerName, int lumSumAmount, int eMINumber)
        {
            BankName = bankName ?? throw new ArgumentNullException(nameof(bankName));
            BorrowerName = borrowerName ?? throw new ArgumentNullException(nameof(borrowerName));
            LumSumAmount = lumSumAmount;
            EMINumber = eMINumber;
        }

        //PAYMENT BANK_NAME BORROWER_NAME LUMP_SUM_AMOUNT EMI_NO
        public string BankName { get; set; }
        public string BorrowerName { get; set; }
        public int LumSumAmount { get; set; }
        public int EMINumber { get; set; }
    }
}
