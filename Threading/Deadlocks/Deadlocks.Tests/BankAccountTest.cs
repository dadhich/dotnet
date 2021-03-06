// <copyright file="BankAccountTest.cs">Copyright ©  2018</copyright>
using System;
using Deadlocks;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Deadlocks.Tests
{
    /// <summary>This class contains parameterized unit tests for BankAccount</summary>
    [PexClass(typeof(BankAccount))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [TestClass]
    public partial class BankAccountTest
    {
        /// <summary>Test stub for Debit(BankAccount, Double)</summary>
        [PexMethod]
        public void DebitTest(
            [PexAssumeUnderTest]BankAccount target,
            BankAccount source,
            double amount
        )
        {
            target.Debit(source, amount);
            // TODO: add assertions to method BankAccountTest.DebitTest(BankAccount, BankAccount, Double)
        }
    }
}
