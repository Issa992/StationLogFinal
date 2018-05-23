namespace StationLogWebApplication1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Task
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TaskId { get; set; }

        public DateTime DateTime { get; set; }

        [Required]
        [StringLength(50)]
        public string Description { get; set; }

        public bool IsRepeatable { get; set; }

        public bool IsDone { get; set; }

        public DateTime SchduledDate { get; set; }

        public int StationId { get; set; }

        public int UserId { get; set; }

        public virtual Station Station { get; set; }

        public virtual User User { get; set; }
    }
}
