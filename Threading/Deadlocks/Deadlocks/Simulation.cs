using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Deadlocks
{
    public class Simulation
    {
        BankAccount[] bankAccounts = new BankAccount[10];
        Random _random = new Random();

        public void Start()
        {
            Thread[] threads = new Thread[5];

            for (int i = 0; i < 10; i++)
            {
                bankAccounts[i] = new BankAccount();
                bankAccounts[i].AccountHolderName = "Account#" + i;
                bankAccounts[i].SetAccountBalance(1000);
            }

            for (int i = 0; i < 5; i++)
            {
                threads[i] = new Thread(DoRandomTransactions);
                threads[i].Name = "Thread" + i;
                threads[i].Start();
            }

            foreach (Thread t in threads)
            {
                t.Join();
                Console.WriteLine("Joined thread: {0}", t.Name);
            }

            int finalTotal = 0;
            foreach (BankAccount bankAccount in bankAccounts)
            {
                finalTotal += bankAccount.GetAccountBalance();
                Console.WriteLine("{0}'s Balance: {1}", bankAccount.AccountHolderName, bankAccount.GetAccountBalance());
            }
            Console.WriteLine("----------- Overall Total: {0} ----------", finalTotal);
        }

        private void DoRandomTransactions()
        {
            int first = 0, second = 0;

            for (int i = 0; i < 1000; i++)
            {
                while (first == second)
                {
                    first = _random.Next(0, 9);
                    second = _random.Next(0, 9);
                }

                int amount = _random.Next(bankAccounts[second].GetAccountBalance());

                if (amount > 0)
                    bankAccounts[first].Credit(bankAccounts[second], amount);
            }
        }
    }
}
