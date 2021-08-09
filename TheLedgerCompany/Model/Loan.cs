using System;
using System.Collections.Generic;

namespace TheLedgerCompany.Model
{
    public class Loan
    {
        public Loan()
        {
            LumSumPaidEMI = new Dictionary<int, int>();
        }

        //BANK_NAME BORROWER_NAME AMOUNT_PAID NO_OF_EMIS_LEFT

        public string BankName { get; set; }
        public string BorrowerName { get; set; }
        public int PrincipalAmount { get; set; }
        public int Tenure { get; set; }
        public int RateOfInterest { get; set; }
        public Dictionary<int, int> LumSumPaidEMI { get; set; }

        public void AddLumSumEMI(int eMINumber, int lumSumAmount)
        {
            if (LumSumPaidEMI.ContainsKey(eMINumber))
                LumSumPaidEMI[eMINumber] = LumSumPaidEMI[eMINumber] + lumSumAmount;
            else
                LumSumPaidEMI[eMINumber] = lumSumAmount;
        }
    }
}
