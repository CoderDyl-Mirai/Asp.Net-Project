using Microsoft.EntityFrameworkCore.ValueGeneration.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using MyProject.Models.Models;
namespace MyProject.Models.Models
{
    public class ShoppingCart
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        [ForeignKey("BookId")]
        [ValidateNever]
        public BookDetails Book { get; set; }
        public int Quantity { get; set; }
        public float CartTotal { get; set; }  
        public string ApplicationUserId { get; set; }
        [ForeignKey("ApplicationUserId")]
        [ValidateNever]

        public ApplicationUser ApplicationUser { get; set; }
    }
}
