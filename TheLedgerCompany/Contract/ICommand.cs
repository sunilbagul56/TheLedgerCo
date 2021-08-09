using TheLedgerCompany.Model;

namespace TheLedgerCompany.Contract
{
    public interface ICommand
    {
        public void ExecuteAsync<TRequest>(TRequest request);
    }
}
