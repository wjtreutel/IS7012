using System.ComponentModel.DataAnnotations;

namespace Week3_BankAccount.Models
{
    public class AccountHolder
    {
        private static int s_accountNumberSeed = 1234567890;
        [Key]
        public string IDNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public bool IsNefarious { get; set; }
        public int IRSNumber { get; set; }


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
