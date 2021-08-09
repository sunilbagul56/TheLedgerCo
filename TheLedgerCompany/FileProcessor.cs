using System.IO;
using TheLedgerCompany.Contract;

namespace TheLedgerCompany
{
    public class FileProcessor : IFileProcessor
    {
        public string[] ProcessInputFile(string fileName)
        {
            using (StreamReader file = new StreamReader(fileName))
            {
                string[] commands = file.ReadToEnd().Split(System.Environment.NewLine);
                file.Close();
                return commands;
            }
        }
    }
}
