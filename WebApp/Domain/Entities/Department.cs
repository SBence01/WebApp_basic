using System.ComponentModel.DataAnnotations;

namespace WebApp.Domain.Entities
{
    public class Department
    {
        [Key]
        public int Id { get; init; }
        [MaxLength(40)]
        public string? Name { get; init; }
    }
}
