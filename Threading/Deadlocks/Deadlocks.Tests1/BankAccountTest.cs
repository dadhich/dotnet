using System;
using Deadlocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Deadlocks.Tests
{
    [TestClass]
    public partial class BankAccountTest
    {
        [TestMethod]
        public void DebitTest_When_SourceAccountIsNull_Then_ErrorMessageSet()
        {
            // arrange
            BankAccount target = new BankAccount();

            // act
            target.Debit(null, 5);

            // assert
            Assert.AreEqual(BankAccount.ERR_SRC_ACCOUNT_NULL_OR_AMOUNT_IS_ZERO, target.GetErrorMessage());
        }

        [TestMethod]
        public void DebitTest_When_DebitAmountIsZero_Then_ErrorMessageSet()
        {
            // arrange
            BankAccount target = new BankAccount();

            // act
            target.Debit(new BankAccount(), 0);

            // assert
            Assert.AreEqual(BankAccount.ERR_SRC_ACCOUNT_NULL_OR_AMOUNT_IS_ZERO, target.GetErrorMessage());
        }

        [TestMethod]
        public void DebitTest_When_DebitAmountIsNegative_Then_ErrorMessageSet()
        {
            // arrange
            BankAccount target = new BankAccount();

            // act
            target.Debit(new BankAccount(), -1);

            // assert
            Assert.AreEqual(BankAccount.ERR_SRC_ACCOUNT_NULL_OR_AMOUNT_IS_ZERO, target.GetErrorMessage());
        }

        [TestMethod]
        public void DebitTest_When_DebitAmountIsMoreThanAccountBalance_Then_ErrorMessageSet()
        {
            // arrange
            BankAccount target = new BankAccount();
            target.SetAccountBalance(1);

            // act
            target.Debit(new BankAccount(), 5);

            // assert
            Assert.AreEqual(BankAccount.ERR_INSUFFICIENT_ACCOUNT_BALANCE, target.GetErrorMessage());
        }

        [TestMethod]
        public void DebitTest_When_DebitAmountIsEqualToAccountBalance_Then_TransactionSuccessful()
        {
            // arrange
            BankAccount target = new BankAccount();
            BankAccount source = new BankAccount();
            target.SetAccountBalance(5);
            source.SetAccountBalance(10);

            // act
            target.Debit(source, 5);

            // assert
            Assert.AreEqual(target.GetAccountBalance(), 0);
            Assert.AreEqual(source.GetAccountBalance(), 15);
        }

        [TestMethod]
        public void DebitTest_When_DebitAmountIsLessThanAccountBalance_Then_TransactionSuccessful()
        {
            // arrange
            BankAccount target = new BankAccount();
            BankAccount source = new BankAccount();
            target.SetAccountBalance(100);
            source.SetAccountBalance(75);

            // act
            target.Debit(source, 10);

            // assert
            Assert.AreEqual(target.GetAccountBalance(), 90);
            Assert.AreEqual(source.GetAccountBalance(), 85);
        }

        [TestMethod]
        public void CreditTest_When_SourceAccountIsNull_Then_ErrorMessageSet()
        {
            // arrange
            BankAccount target = new BankAccount();

            // act
            target.Credit(null, 5);

            // assert
            Assert.AreEqual(BankAccount.ERR_SRC_ACCOUNT_NULL_OR_AMOUNT_IS_ZERO, target.GetErrorMessage());
        }

        [TestMethod]
        public void CreditTest_When_DebitAmountIsZero_Then_ErrorMessageSet()
        {
            // arrange
            BankAccount target = new BankAccount();

            // act
            target.Credit(new BankAccount(), 0);

            // assert
            Assert.AreEqual(BankAccount.ERR_SRC_ACCOUNT_NULL_OR_AMOUNT_IS_ZERO, target.GetErrorMessage());
        }

        [TestMethod]
        public void CreditTest_When_CreditAmountIsNegative_Then_ErrorMessageSet()
        {
            // arrange
            BankAccount target = new BankAccount();

            // act
            target.Credit(new BankAccount(), -5);

            // assert
            Assert.AreEqual(BankAccount.ERR_SRC_ACCOUNT_NULL_OR_AMOUNT_IS_ZERO, target.GetErrorMessage());
        }

        [TestMethod]
        public void CreditTest_When_CreditAmountIsMoreThanSourceAccountsBalance_Then_ErrorMessageSet()
        {
            // arrange
            BankAccount target = new BankAccount();
            BankAccount source = new BankAccount();
            source.SetAccountBalance(100);

            // act
            target.Credit(source, 105);

            // assert
            Assert.AreEqual(BankAccount.ERR_INSUFFICIENT_ACCOUNT_BALANCE, target.GetErrorMessage());
        }

        [TestMethod]
        public void CreditTest_When_CreditAmountIsEqualToSourceAccountsBalance_Then_TransactionSuccessful()
        {
            // arrange
            BankAccount target = new BankAccount();
            BankAccount source = new BankAccount();
            target.SetAccountBalance(100);
            source.SetAccountBalance(50);

            // act
            target.Credit(source, 50);

            // assert
            Assert.AreEqual(source.GetAccountBalance(), 0);
            Assert.AreEqual(target.GetAccountBalance(), 150);
        }

        [TestMethod]
        public void CreditTest_When_CreditAmountIsLessThanSourceAccountsBalance_Then_TransactionSuccessful()
        {
            // arrange
            BankAccount target = new BankAccount();
            BankAccount source = new BankAccount();
            target.SetAccountBalance(100);
            source.SetAccountBalance(75);

            // act
            target.Credit(source, 10);

            // assert
            Assert.AreEqual(target.GetAccountBalance(), 110);
            Assert.AreEqual(source.GetAccountBalance(), 65);
        }
    }
}
