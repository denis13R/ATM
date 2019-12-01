namespace ATM.Web.ViewModels
{
    public class WithdrawResultViewModel
    {
        public string CardNum { get; set; }

        public string CardNumWithDashes { get; set; }

        public string DateAndTime { get; set; }

        public decimal WithdrewAmount { get; set; }

        public decimal Balance { get; set; }

        public string BackController { get; set; }

        public string BackAction { get; set; }
    }
}