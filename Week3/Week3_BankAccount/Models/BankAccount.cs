using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        [DisplayName("ID")]
        public string IDNumber { get; set; }
        [DisplayName("Current Balance")]
        public double CurrentBalance { get; set; }
        [DisplayName("Name")] // (for consistency)
        public string Name { get; set; }
        [DisplayName("IRS #")]
        public Nullable<int> IRSNumber { get; set; }
        [DisplayName("Account Holder ID")]
        public string AccountholderID { get; set; }

        public BankAccount()
        {
            this.IDNumber = s_accountNumberSeed.ToString("0000000000");
            this.Name = this.IDNumber;
            this.CurrentBalance = 0;
            s_accountNumberSeed++;

            this.AccountholderID = "0";
            this.IRSNumber = 0; // filled by some other function
        }


        public BankAccount(string name, double initialBalance, string accountholderID = "")
        {
            this.Name = name;
            this.CurrentBalance = initialBalance;
            this.IDNumber = s_accountNumberSeed.ToString("000000000000"); // dream bigger. our bank is going to serve the entire planet.
            s_accountNumberSeed++;

            this.AccountholderID = accountholderID;
            this.IRSNumber = 0; // filled by some other function
        }


        // leave room to add other functionality later -- perhaps logging, records update, etc.
        public void AssignAccount(string newAccountholder)
        {
            this.AccountholderID = newAccountholder;
        }
    }
}
