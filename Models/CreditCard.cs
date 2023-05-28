using System.ComponentModel.DataAnnotations;

namespace credit_card_app_backend.Models
{
    // CreditCard class allows modeling a credit card item and map
    // its declared variables to the database information
    public class CreditCard
    {
        // Variable to set the credit card id
        [Key
            ]
        public int id {  get; set; }
        
        // Variable to set the credit card's owner user name
        [Required]
        public string user { get; set; }

        // Variable to set the credit card number
        [Required]
        public string cardNumber { get; set; }

        // Variable to set the expiration date of the credit card
        [Required]
        public string endDate { get; set; }

        // Variable to set the CVV number
        [Required]
        public string cvv { get; set; }
    }
}
