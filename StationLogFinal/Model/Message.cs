namespace StationLogWebApplication1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Message
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MessageId { get; set; }

        [Required]
        public string Description { get; set; }

        public int MonitorId { get; set; }

        public int LogId { get; set; }

        public virtual Log Log { get; set; }

        public virtual Monitor Monitor { get; set; }

        //Not same as in communication folder
    }
}
