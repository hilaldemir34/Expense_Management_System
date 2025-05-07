using ExpenseManagementSystem.Domain.BaseEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseManagementSystem.Domain.Entities
{
    public class ExpenseDocument : EntityBase
    {     
        public Guid FileId { get; set; }       
        public string FileName { get; set; }  
        public string Location { get; set; }     
        public int ExpenseRequestId { get; set; }
        public ExpenseRequest ExpenseRequest { get; set; }
    }
}
