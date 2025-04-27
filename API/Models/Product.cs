// API/Models/Product.cs
using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public long LastModified { get; set; }
    }
}
