using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week3_BankAccount.Models
{
    public class BankAccount
    {
        private static int s_accountNumberSeed = 1234567890;

        [Key]
        public string IDNumber { get; set; }
        public decimal CurrentBalance { get; set; }
        public string Name { get; set; }
        public int IRSNumber { get; set; }
        public int AccountholderID { get; set; }

        public BankAccount()
        {
            this.IDNumber = s_accountNumberSeed.ToString("0000000000");
            this.Name = this.IDNumber;
            this.CurrentBalance = 0;
            s_accountNumberSeed++;

            this.AccountholderID = 0;
            this.IRSNumber = 0; // filled by some other function
        }


        public BankAccount(string name, decimal initialBalance, int accountholderID = 0)
        {
            this.Name = name;
            this.CurrentBalance = initialBalance;
            this.IDNumber = s_accountNumberSeed.ToString("000000000000"); // dream bigger. our bank is going to serve the entire planet.
            s_accountNumberSeed++;

            this.AccountholderID = accountholderID;
            this.IRSNumber = 0; // filled by some other function
        }


        // leave room to add other functionality later -- perhaps logging, records update, etc.
        public void AssignAccount(int newAccountholder)
        {
            this.AccountholderID = newAccountholder;
        }
    }
}
