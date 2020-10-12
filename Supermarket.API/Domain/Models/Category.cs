using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Supermarket.API.Domain.Models
{
    [Table("Categories")]
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IList<Product> Products { get; set; } = new List<Product>();
    }
}
