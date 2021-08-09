using System.Collections.Generic;
using TheLedgerCompany.Model;

namespace TheLedgerCompany.Contract
{
    public interface IDataRepository
    {
        public Dictionary<string, Loan> DataContext { get; set; }

        public Loan GetLoanInfo(string identifier);
        public void AddLoan(string identifier, Loan loan);
        public string GetIdentifier(string bankName, string borrowerName);
    }
}
