using System.Collections.Generic;
using TheLedgerCompany.Contract;
using TheLedgerCompany.Model;

namespace TheLedgerCompany.Repository
{
    public class DataRepository : IDataRepository
    {
        public Dictionary<string, Loan> DataContext { get; set; }

        public DataRepository()
        {
            DataContext = new Dictionary<string, Loan>();
        }

        public string GetIdentifier(string bankName, string borrowerName)
        {
            bankName.EnsureNotNullOrEmpty(nameof(bankName));
            borrowerName.EnsureNotNullOrEmpty(nameof(borrowerName));
            return $"{bankName}-{borrowerName}";
        }

        public Loan GetLoanInfo(string identifier)
        {
            DataContext.EnsureCollectionNotNullOrEmpty(nameof(DataContext));

            if (DataContext.ContainsKey(identifier))
                return DataContext[identifier];
            else
                throw new KeyNotFoundException($"The given loan account {identifier} not found");
        }

        public void AddLoan(string identifier, Loan loan)
        {
            DataContext.Add(identifier, loan);
        }
    }
}
