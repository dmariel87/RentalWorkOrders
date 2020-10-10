using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentalWorkOrders.Models
{
    public partial class Statuses
    {
        public Statuses()
        {
            WorkOrders = new HashSet<WorkOrders>();
        }

        [Key]
        [Column("Status_ID")]
        public int StatusId { get; set; }
        [Required]
        [StringLength(20)]
        public string Title { get; set; }
        [Column("Date_Created", TypeName = "datetime")]
        public DateTime DateCreated { get; set; }

        [InverseProperty("Status")]
        public virtual ICollection<WorkOrders> WorkOrders { get; set; }
    }
}
