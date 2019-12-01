namespace ATM.Web.ViewModels
{
    public class BalanceViewModel
    {
        public string CardNum { get; set; }

        public string CardNumWithDashes { get; set; }

        public string Date { get; set; }

        public decimal Balance { get; set; }

        public string BackController { get; set; }

        public string BackAction { get; set; }
    }
}