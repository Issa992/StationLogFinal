namespace StationLogWebApplication1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Measurement
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MeasurementId { get; set; }

        public int MonitorId { get; set; }

        [Required]
        [StringLength(50)]
        public string Description { get; set; }

        public int LogId { get; set; }

        public virtual Log Log { get; set; }

        public virtual Monitor Monitor { get; set; }
    }
}
