using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseManagementSystem.Application.Features.ExpenseCategories.DTOs
{
    public class UpdateExpenseCategoryDto
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }

    }
}
