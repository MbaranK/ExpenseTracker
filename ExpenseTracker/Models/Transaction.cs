using Castle.Components.DictionaryAdapter;
using System.Reflection.Metadata.Ecma335;
using System.ComponentModel.DataAnnotations;
using KeyAttribute = System.ComponentModel.DataAnnotations.KeyAttribute;
using Castle.MicroKernel.SubSystems.Conversion;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExpenseTracker.Models
{
    public class Transaction
    {
        [Key]
        public int TransactionId { get; set; }

        //CategoryId Foreign key
        [Range(1,int.MaxValue, ErrorMessage ="Please select a category")]
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
        //
        [Range(1, int.MaxValue, ErrorMessage = "Amount should be greater than 0")]
        public int Amount { get; set; }
        [Column(TypeName = "nvarchar(75)")]
        public string? Note { get; set; }
        public DateTime Date { get; set; } = DateTime.Now; // Default value.

        [NotMapped]
        public string? CategoryTitleWithIcon
        {
            get
            {
                return Category == null ? "" : Category.Icon + " " + Category.Title;
            }

        }

        [NotMapped]
        public string? FormattedAmount
        {
            get
            {
                return ((Category == null || Category.Type == "Expense") ? "-" : "+") + Amount.ToString();
            }

        }

    }
}
