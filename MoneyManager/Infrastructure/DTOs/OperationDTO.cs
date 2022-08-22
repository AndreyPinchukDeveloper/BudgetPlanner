using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyManager.Infrastructure.DTOs
{
    public class OperationDTO
    {
        [Key]
        public Guid Id { get; set; }
        public string AmountOfMoney { get; set; }
        public string TypeOfOperation { get; set; }
        public DateTime TimeOfChange { get; set; }
        public string Categories { get; set; }
        public string Note { get; set; }
    }
}
