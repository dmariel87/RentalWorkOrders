using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentalWorkOrders.Models
{
    public partial class Residents
    {
        public Residents()
        {
            WorkOrders = new HashSet<WorkOrders>();
        }

        [Key]
        [Column("Resident_ID")]
        public int ResidentId { get; set; }
        [Required]
        [Column("First_Name")]
        [StringLength(30)]
        public string FirstName { get; set; }
        [Required]
        [Column("Last_Name")]
        [StringLength(30)]
        public string LastName { get; set; }
        [Required]
        [StringLength(30)]
        public string Address { get; set; }
        [Required]
        [Column("Unit_Number")]
        [StringLength(30)]
        public string UnitNumber { get; set; }
        [Required]
        [StringLength(30)]
        public string City { get; set; }
        [Required]
        [StringLength(30)]
        public string State { get; set; }
        [Required]
        [StringLength(15)]
        public string Zip { get; set; }
        [Required]
        [StringLength(15)]
        public string Phone { get; set; }
        [Required]
        [StringLength(50)]
        public string Email { get; set; }
        [Column("Date_Created", TypeName = "datetime")]
        public DateTime DateCreated { get; set; }

        [InverseProperty("Resident")]
        public virtual ICollection<WorkOrders> WorkOrders { get; set; }
    }
}
