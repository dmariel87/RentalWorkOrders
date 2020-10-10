using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentalWorkOrders.Models
{
    public partial class Employees
    {
        public Employees()
        {
            WorkOrders = new HashSet<WorkOrders>();
        }

        [Key]
        [Column("Employee_ID")]
        public int EmployeeId { get; set; }
        [Required]
        [Column("First_Name")]
        [StringLength(30)]
        public string FirstName { get; set; }
        [Required]
        [Column("Last_Name")]
        [StringLength(30)]
        public string LastName { get; set; }
        [Required]
        [StringLength(50)]
        public string Email { get; set; }
        [Required]
        [StringLength(50)]
        public string Password { get; set; }
        [Column("Date_Created", TypeName = "datetime")]
        public DateTime DateCreated { get; set; }

        [InverseProperty("Employee")]
        public virtual ICollection<WorkOrders> WorkOrders { get; set; }
    }
}
