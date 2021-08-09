using System;
using TheLedgerCompany.Contract;
using TheLedgerCompany.Model;
using TheLedgerCompany.Translator;

namespace TheLedgerCompany.Command
{
    public class LoadCommand : ICommand
    {
        private IDataRepository _dataRepository;

        public LoadCommand(IDataRepository dataRepository)
        {
            _dataRepository = dataRepository ?? throw new ArgumentNullException(nameof(dataRepository));
        }

        public void ExecuteAsync<TRequest>(TRequest request)
        {
            request.EnsureNotNull(nameof(LoadCommandRequest));
            var loadCommandRequest = request as LoadCommandRequest;
            string identifier = _dataRepository.GetIdentifier(loadCommandRequest.BankName, loadCommandRequest.BorrowerName);
            _dataRepository.AddLoan(identifier, loadCommandRequest.TranslateToDataContext());
        }
    }
}
