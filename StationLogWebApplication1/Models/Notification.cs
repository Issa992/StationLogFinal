namespace StationLogWebApplication1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Notification")]
    public partial class Notification
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int NotificationId { get; set; }

        public DateTime DeadLine { get; set; }

        [Required]
        public string Message { get; set; }

        public bool IsRed { get; set; }

        public int StationId { get; set; }

        public virtual Station Station { get; set; }
    }
}
