namespace StationLogWebApplication1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Alert")]
    public partial class Alert
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int AlertId { get; set; }

        public DateTime DeadLine { get; set; }

        [Required]
        public string Message { get; set; }

        public bool IsRed { get; set; }

        public bool IsToggled { get; set; }

        public int StationId { get; set; }
    }
}
