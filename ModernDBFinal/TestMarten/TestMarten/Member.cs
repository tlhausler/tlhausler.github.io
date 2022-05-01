using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    class Member
    {
        public double pendingDebits = 0;
        public int Id { get; set; }
        public string Name { get; set; }
        public Account MemberAccount { get; set; }
        public List<Transaction> TransactionList { get; set; }

        public double PendingDebits()
        {
            foreach (Transaction trans in TransactionList)
            {
                pendingDebits += trans.GetDebitAmount();
            }
            return pendingDebits;
        }

        public double BalanceAfterDebits()
        {
            double balance = MemberAccount.GetBalance();
            balance += pendingDebits;
            MemberAccount.Balance = balance;
            return balance;
        }

        public void ClearPendingDebits()
        {
            pendingDebits = 0;
        }
    }
}
