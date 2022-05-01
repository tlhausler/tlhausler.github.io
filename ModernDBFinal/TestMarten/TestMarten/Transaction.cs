using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    class Transaction
    {
        public int TransactionID { get; set; }
        public string BusinessName { get; set; }
        public double DebitAmount { get; set; }

        public double GetDebitAmount()
        {
            return DebitAmount;
        }

        public override string ToString()
        {
            return "Transaction ID: " + TransactionID + " " + BusinessName + " $" + DebitAmount;
        }
    }
}
