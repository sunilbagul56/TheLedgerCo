using TheLedgerCompany.Model;

namespace TheLedgerCompany.Translator
{
    public static class LoadCommandRequestTranslator
    {
        public static Loan TranslateToDataContext(this LoadCommandRequest loadCommandRequest)
        {
            return new Loan()
            {
                BankName = loadCommandRequest.BankName,
                BorrowerName = loadCommandRequest.BorrowerName,
                Tenure = loadCommandRequest.NoOfYears,
                RateOfInterest = loadCommandRequest.RateOfInterest,
                PrincipalAmount = loadCommandRequest.PrincipalAmount
            };
        }
    }
}
