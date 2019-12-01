using System;

namespace ATM.DataAccess.Entities
{
    public class Operation
    {
        public int OperationId { get; set; }

        public int CardId { get; set; }

        public string CardNum { get; set; }

        public string OperationCode { get; set; }

        public decimal WithdrewMoneyAmount { get; set; }

        public DateTime OperationDateTime { get; set; }

    }
}