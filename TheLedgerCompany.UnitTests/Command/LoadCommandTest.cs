using FluentAssertions;
using System;
using TheLedgerCompany.Command;
using TheLedgerCompany.Contract;
using TheLedgerCompany.Model;
using TheLedgerCompany.Repository;
using Xunit;

namespace TheLedgerCompany.UnitTests
{
    public class LoadCommandTest
    {
        public ICommand _loadCommand;
        public IDataRepository _dataRepository;

        public LoadCommandTest()
        {
            _dataRepository = new DataRepository();
            _loadCommand = new LoadCommand(_dataRepository);
        }

        [Fact]
        public void ExecuteAsync_InvalidReuest_Throws_ArgumentNullException_Test()
        {
            //Arrange
            LoadCommandRequest loadCommandRequest = null;

            //Act
            Action response = () => _loadCommand.ExecuteAsync(loadCommandRequest);

            //Assert
            response.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void ExecuteAsync_AddLoan_ValidReuest_Should_Return_Valid_Response_Test()
        {
            //Arrange
            var key = "IDBI-DAL";
            var loan = new Loan() { BankName = "IDBI", BorrowerName = "DAL", PrincipalAmount = 12000, RateOfInterest = 7, Tenure = 1 };
            string identifier = _dataRepository.GetIdentifier(loan.BankName, loan.BorrowerName);

            //Act
            _dataRepository.AddLoan(key, loan);

            //Assert
            identifier.Should().NotBeNullOrEmpty();
            _dataRepository.DataContext.Count.Should().BeGreaterThan(0);
        }
    }
}
