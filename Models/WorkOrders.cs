using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentalWorkOrders.Models
{
    [Table("Work_Orders")]
    public partial class WorkOrders
    {
        [Key]
        [Column("Work_Order_ID")]
        public int WorkOrderId { get; set; }
        [Required]
        [StringLength(1500)]
        public string Description { get; set; }
        [Column("Resident_ID")]
        public int? ResidentId { get; set; }
        [Column("Status_ID")]
        public int? StatusId { get; set; }
        [Column("Employee_ID")]
        public int? EmployeeId { get; set; }
        [Required]
        [StringLength(1500)]
        public string Notes { get; set; }
        [Column("Date_Completed", TypeName = "datetime")]
        public DateTime? DateCompleted { get; set; }
        [Column("Date_Updated", TypeName = "datetime")]
        public DateTime DateUpdated { get; set; }
        [Column("Date_Created", TypeName = "datetime")]
        public DateTime DateCreated { get; set; }

        [ForeignKey(nameof(EmployeeId))]
        [InverseProperty(nameof(Employees.WorkOrders))]
        public virtual Employees Employee { get; set; }
        [ForeignKey(nameof(ResidentId))]
        [InverseProperty(nameof(Residents.WorkOrders))]
        public virtual Residents Resident { get; set; }
        [ForeignKey(nameof(StatusId))]
        [InverseProperty(nameof(Statuses.WorkOrders))]
        public virtual Statuses Status { get; set; }
    }
}
