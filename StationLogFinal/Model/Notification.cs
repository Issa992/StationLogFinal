namespace StationLogWebApplication1
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
        public Notification()
        {
            IsRed = false;
        }
        public Notification(int id, int stationid, DateTime date,
           string mess)
        {
            NotificationId = id; StationId = stationid;
            DeadLine = date; Message = mess;
            IsRed = false;
        }
        public int getID()
        {
            return NotificationId;
        }

        public void MarkAsRed()
        {
            IsRed = true;
        }
    }
}
