using System;
using TheLedgerCompany.Contract;
using TheLedgerCompany.Model;

namespace TheLedgerCompany
{
    public class CommandInvoker
    {
        private ICommand _loadCommand;
        private ICommand _balanceCommand;
        private ICommand _paymentCommand;

        public CommandInvoker(ICommand loadCommand, ICommand balanceCommand, ICommand paymentCommand)
        {
            _loadCommand = loadCommand ?? throw new ArgumentNullException(nameof(loadCommand));
            _balanceCommand = balanceCommand ?? throw new ArgumentNullException(nameof(balanceCommand));
            _paymentCommand = paymentCommand ?? throw new ArgumentNullException(nameof(paymentCommand));
        }

        public void InvokeCommand(string[] commands)
        {
            if (commands != null && commands.Length > 0)
            {
                foreach (string cmd in commands)
                {
                    var commandDetails = cmd.Split(" ");
                    ProcessCommand(commandDetails);
                }
            }
            else
                Console.WriteLine("Plase provide correct commands");
        }

        private void ProcessCommand(string[] commandDetails)
        {
            var command = commandDetails[0];

            switch (command)
            {
                case KeyStore.Command.LOAN:
                    var loadCommandRequest = new LoadCommandRequest(commandDetails[1], commandDetails[2],
                        Int32.Parse(commandDetails[3]), Int32.Parse(commandDetails[4]), Int32.Parse(commandDetails[5]));
                    _loadCommand.ExecuteAsync<LoadCommandRequest>(loadCommandRequest);
                    break;

                case KeyStore.Command.BALANCE:
                    var balanceCommandRequest = new BalanceCommandRequest(commandDetails[1], commandDetails[2], Int32.Parse(commandDetails[3]));
                    _balanceCommand.ExecuteAsync<BalanceCommandRequest>(balanceCommandRequest);
                    break;

                case KeyStore.Command.PAYMENT:
                    var paymentCommandRequest = new PaymentCommandRequest(commandDetails[1], commandDetails[2], Int32.Parse(commandDetails[3]), Int32.Parse(commandDetails[4]));
                    _paymentCommand.ExecuteAsync<PaymentCommandRequest>(paymentCommandRequest);
                    break;
            }
        }
    }
}
