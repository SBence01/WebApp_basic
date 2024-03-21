using System.ComponentModel.DataAnnotations;
using WebApp.Controllers;

namespace WebApp.Domain.Entities
{
    public class Employee
    {
        [Key]
        public int Id { get; init; }
        [MaxLength(20)]
        public string? FirstName { get; init; }
        [MaxLength(20)]
        public string? LastName { get; init; }
        public int ManNumber { get; init; }
        public int DepartmentId { get; init; }

    }
}
