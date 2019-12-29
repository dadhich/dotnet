using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Deadlocks
{
    public class BankAccount
    {
        public const string ERR_SRC_ACCOUNT_NULL_OR_AMOUNT_IS_ZERO = "Either source account is NULL or amount is less than or equal to zero";
        public const string ERR_INSUFFICIENT_ACCOUNT_BALANCE = "Insufficient account balance";
        private object _syncObj = new object();

        public int AccountNumber { get; set; }

        public string AccountHolderName { get; set; }

        private int _accountBalance = int.MinValue;

        public int GetAccountBalance()
        {
            return _accountBalance;
        }

        public void SetAccountBalance(int newBalance)
        {
            //lock(_syncObj)
            //{
                _accountBalance = newBalance;
            //}
        }

        private string _errorMessage = string.Empty;

        public string GetErrorMessage()
        {
            return _errorMessage;
        }

        public void Debit(BankAccount source, int amount)
        {
            if(!IsSourceNullOrAmountZero(source, amount) && !IsInsufficientFund(this, amount))
            {
                int sourceAccountBalance = source.GetAccountBalance();
                source.SetAccountBalance(sourceAccountBalance + amount);
                this.SetAccountBalance(this.GetAccountBalance() - amount);
                Console.WriteLine("D.Thread[{0}]: Transferred ${1} from '{2}' to '{3}'", Thread.CurrentThread.Name, 
                    amount, AccountHolderName, source.AccountHolderName);
            }
        }

        public void Credit(BankAccount source, int amount)
        {
            if(!IsSourceNullOrAmountZero(source, amount) && !IsInsufficientFund(source, amount))
            {
                int sourceAccountBalance = source.GetAccountBalance();

                source.SetAccountBalance(sourceAccountBalance - amount);
                this.SetAccountBalance(this.GetAccountBalance() + amount);
                Console.WriteLine("C.Thread[{3}]: Transferred ${0} from '{1}' to '{2}'", amount, source.AccountHolderName, AccountHolderName, Thread.CurrentThread.Name);
            }
        }

        private bool IsInsufficientFund(BankAccount source, double amount)
        {
            if (source.GetAccountBalance() < amount)
            {
                _errorMessage = ERR_INSUFFICIENT_ACCOUNT_BALANCE;
                Console.WriteLine("Thread[" + Thread.CurrentThread.Name + "]:" + ERR_INSUFFICIENT_ACCOUNT_BALANCE);
                return true;
            }

            return false;
        }

        private bool IsSourceNullOrAmountZero(BankAccount source, double amount)
        {
            if (source == null || amount <= 0)
            {
                _errorMessage = ERR_SRC_ACCOUNT_NULL_OR_AMOUNT_IS_ZERO;
                Console.WriteLine("Thread[" + Thread.CurrentThread.Name + "]:" + ERR_SRC_ACCOUNT_NULL_OR_AMOUNT_IS_ZERO);
                return true;
            }

            return false;
        }
    }
}
