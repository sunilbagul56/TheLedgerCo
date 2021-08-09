using FluentAssertions;
using System;
using System.Collections.Generic;
using TheLedgerCompany.Contract;
using TheLedgerCompany.Model;
using TheLedgerCompany.Repository;
using Xunit;

namespace TheLedgerCompany.UnitTests
{
    public class DataRepositoryTest
    {
        public IDataRepository _dataRepository;

        public DataRepositoryTest()
        {
            _dataRepository = new DataRepository();
        }

        [Fact]
        public void GetIdentifier_Test()
        {
            //Arrange
            var bankName = "IDBI";
            var borrowerName = "DAL";

            //Act
            var identifier = _dataRepository.GetIdentifier(bankName, borrowerName);

            //Assert
            identifier.Should().NotBeNull();
            identifier.Should().Be($"{bankName}-{borrowerName}");
        }

        [Fact]
        public void GetLoanInfo_Should_Return_Valid_Data_Test()
        {
            //Arrange
            var loan = new Loan() { BankName = "IDBI", BorrowerName = "DAL", PrincipalAmount = 12000, RateOfInterest = 7, Tenure = 1 };
            var identifier = _dataRepository.GetIdentifier(loan.BankName, loan.BorrowerName);
            _dataRepository.AddLoan(identifier, loan);

            //Act
            var getLoanData = _dataRepository.GetLoanInfo(identifier);

            //Assert
            getLoanData.Should().NotBeNull();
            getLoanData.BankName.Should().NotBeNull();
            getLoanData.BankName.Should().NotBeNullOrEmpty();

            getLoanData.BorrowerName.Should().NotBeNull();
            getLoanData.BorrowerName.Should().NotBeNullOrEmpty();

            getLoanData.PrincipalAmount.Should().BeGreaterThan(0);
        }

        [Theory]
        [InlineData("")]
        [InlineData("Invalid-Key")]
        public void GetLoanInfo_Should_Throw_KeyNotFoundException_Test(string identifier)
        {
            //Arrange
            var key = "IDBI-DAL";
            var loan = new Loan() { BankName = "IDBI", BorrowerName = "DAL", PrincipalAmount = 12000, RateOfInterest = 7, Tenure = 1 };
            _dataRepository.AddLoan(key, loan);

            //Act
            Action response = () => _dataRepository.GetLoanInfo(identifier);

            //Assert
            response.Should().Throw<KeyNotFoundException>();
        }
    }
}
