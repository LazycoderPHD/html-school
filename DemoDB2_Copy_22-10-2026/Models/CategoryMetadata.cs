using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemoDB2.Models
{
    public partial class Category
    {
        [NotMapped]
        public List<Category> ListCate { get; set; }
    }
}