using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ATM.DataAccess.Entities
{

    public class Card
    {
        public int CardId { get; set; }

        [Column(TypeName = "CHAR")]
        [StringLength(16)]
        [Index]
        public string CardNum { get; set; }

        [Column(TypeName = "CHAR")]
        [StringLength(4)]
        public string PinCode { get; set; }

        public decimal Balance { get; set; }

        public bool IsActive { get; set; }
    }
}