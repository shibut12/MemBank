namespace MemBank.Service
{
    public class Account
    {
        public int AccountId { get; set; }
        public string TypeName { get; set; }
        public decimal Balance { get; set; }
        public decimal WithdrawLimit { get; set; }
        public string Owner { get; set; }
    }
}
