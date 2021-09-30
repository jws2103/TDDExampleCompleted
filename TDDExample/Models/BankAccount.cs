using PropertyChanged;

namespace TDDExample
{
    [AddINotifyPropertyChangedInterface]
    public class BankAccount
    {
        /// <summary>
        /// Gets or sets account holder name
        /// </summary>
        public string AccountName { get; set; }

        /// <summary>
        /// Gets or set account number
        /// </summary>
        public string AccountNumber { get; set; }

        /// <summary>
        /// Gets or sets bsb number
        /// </summary>
        public string BSBNumber { get; set; }

        /// <summary>
        /// Gets or sets account balance
        /// </summary>
        public double Balance { get; set; }
    }
}
