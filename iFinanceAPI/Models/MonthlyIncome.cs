using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace iFinanceAPI.Models
{
    public class MonthlyIncome
    {
        [Required]
        [Key]
        public int IncomeID { get; set; }

        public string Origin { get; set; }

        public decimal Amount { get; set; }

        public DateTime Date { get; set; }

    }
}
