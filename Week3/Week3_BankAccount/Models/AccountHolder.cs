using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Week3_BankAccount.Models
{
    public class AccountHolder
    {
        private static int s_accountNumberSeed = 1234567890;
        [Key]
        [DisplayName("ID")]
        public string IDNumber { get; set; }
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        [DisplayName("Last Name")]
        public string LastName { get; set; }
        [DisplayName("Date of Birth")]
        public DateOnly DateOfBirth { get; set; }
        [DisplayName("Nefarious?")]
        public bool IsNefarious { get; set; }
        [DisplayName("IRS #")] // several ways to slice this, but (against my tastes) this is the format I've most encountered in industry
        public Nullable<int> IRSNumber { get; set; }


        public AccountHolder()
        {
            this.IDNumber = s_accountNumberSeed.ToString("000000000000");
            s_accountNumberSeed++;

            this.IsNefarious = false;
            this.IRSNumber = 0; // see above
        }

        public AccountHolder(string firstName, string lastName, DateOnly dateOfBirth, bool isCriminal = false)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.DateOfBirth = dateOfBirth;
            this.IDNumber = s_accountNumberSeed.ToString("000000000000");
            s_accountNumberSeed++;

            if (isCriminal) { throw new Exception("Error: Do not commit fraud, please."); }
            this.IsNefarious = isCriminal;
            this.IRSNumber = 0; // see above
        }
    }
}
