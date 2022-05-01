using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.Configuration;
using Marten;
using System.Collections;

namespace FinalProject
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MtDocumentDB"].ConnectionString;
            IDocumentStore store = DocumentStore.For(connectionString);

            using (var docDb = store.OpenSession())
            {
                // Create transactions and add them to ArrayList()
                List<Transaction> memberTransactions = new List<Transaction>();
                Transaction t1 = new Transaction { TransactionID = 22358, BusinessName = "Big Dipper", DebitAmount = -7.49 };
                memberTransactions.Add(t1);
                Transaction t2 = new Transaction { TransactionID = 72598, BusinessName = "Taco Del Sol", DebitAmount = -10.71 };
                memberTransactions.Add(t2);
                Transaction t3 = new Transaction { TransactionID = 67318, BusinessName = "Winco", DebitAmount = -76.33 };
                memberTransactions.Add(t3);
                Transaction t4 = new Transaction { TransactionID = 29294, BusinessName = "Employer", DebitAmount = 1473.61 };
                memberTransactions.Add(t4);

                Account memberAccount = new Account { Id = 113668, AccountName = "Checking", Balance = 12403.74 };

                Member newMember = new Member { Name = "Marcus Locke", MemberAccount = memberAccount, TransactionList = memberTransactions };
                docDb.Store(newMember);
                docDb.SaveChanges();

                Console.WriteLine($"{newMember.Name} Account #{newMember.MemberAccount.Id} {newMember.MemberAccount.AccountName} Balance of: {newMember.MemberAccount.Balance}");
                Console.WriteLine("Transactions: ");
                foreach (Transaction trans in memberTransactions)
                {
                    Console.WriteLine(trans);
                };

                double totalPending = newMember.PendingDebits();
                double balanceAfter = newMember.BalanceAfterDebits();

                Member memUpdate = docDb.Query<Member>().FirstOrDefault(x => x.Name == "Marcus Locke");
                memUpdate.MemberAccount.Balance = balanceAfter;
                docDb.Store(memUpdate);
                docDb.SaveChanges();

                Console.WriteLine($"Pending Debit Total: ${totalPending} \nPending Balance: ${balanceAfter}");



                //Member memUpdate = docDb.Query<Member>().FirstOrDefault(x => x.Name == "Marcus Locke");
                //memUpdate.Name = "Madison Heath";
                //docDb.Store(memUpdate);
                //docDb.SaveChanges();

                //Console.WriteLine(memUpdate.Name);

                //docDb.Delete<Member>(memUpdate);
                //docDb.SaveChanges();

                Console.ReadLine();
            }
        }
    }
}
