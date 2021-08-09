using System;
using TheLedgerCompany.Command;
using TheLedgerCompany.Repository;

namespace TheLedgerCompany
{
    class Program
    {
        static void Main(string[] args)
        {
            //Get loan command details from file
            var fileProcessor = new FileProcessor();
            string fileName = "TheLedgerCo-Sample.txt";
            //string fileName = "TheLedgerCo-Sample-1.txt";

            //Get text file from currect directory
            //var path = System.Environment.CurrentDirectory;

            string[] commands = fileProcessor.ProcessInputFile(fileName);

            //Process all the commands
            var dataRepository = new DataRepository();
            Console.WriteLine("-----------------------------THE LEDGER COMPANY-------------------------------");
            Console.WriteLine("BankName \t BorroweName \t TotalAmountPaid \t NewTenureInMonths");
            Console.WriteLine("------------------------------------------------------------------------------");

            var commandInvoker = new CommandInvoker(new LoadCommand(dataRepository), new BalanceCommand(dataRepository), new PaymentCommand(dataRepository));
            commandInvoker.InvokeCommand(commands);
        }
    }
}
