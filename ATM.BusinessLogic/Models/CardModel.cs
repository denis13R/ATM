namespace ATM.BusinessLogic.Models
{
    public class CardModel
    {
        public int CardId { get; set; }

        public string CardNum { get; set; }

        public string PinCode { get; set; }

        public decimal Balance { get; set; }

        public bool IsActive { get; set; }
    }
}