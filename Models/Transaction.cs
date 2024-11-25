using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesLab1.Models
{
    public class Transaction
    {
        [Key]
        public int TId { get; set; }
        [Required]
        public string sourceAccNumber { get; set; }
        [Required]
        public decimal amount { get; set; }

        public string operation { get; set; }

        //navigation property
        [ForeignKey(nameof(transaction))]
        public int Id { get; set; }
        public virtual BankAccount transaction { get; set; }
    }
}
