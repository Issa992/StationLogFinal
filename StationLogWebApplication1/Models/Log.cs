namespace StationLogWebApplication1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Log
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int LogId { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public DateTime DateTime { get; set; }

        [Required]
        [StringLength(50)]
        public string Type { get; set; }

        public int UserId { get; set; }

        public int StationId { get; set; }

        public int MeasurementId { get; set; }

        public int CommentId { get; set; }

        public virtual User User { get; set; }

        public virtual Station Station { get; set; }
    }
}
