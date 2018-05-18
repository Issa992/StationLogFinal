namespace StationLogWebApplication1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TaskModel
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

        //public virtual Station Station { get; set; }

        //public virtual User User { get; set; }
        public DateTimeOffset DateOffset
        {
            get { return DateTime.SpecifyKind(DateTime, DateTimeKind.Utc); }
            set { DateTime = value.DateTime; }
        }
        public DateTimeOffset DateOffsetSchduledDate
        {
            get { return DateTime.SpecifyKind(DateTime, DateTimeKind.Utc); }
            set { SchduledDate = value.DateTime; }
        }
        public TaskModel(int taskId, DateTime dateTime, string description, bool isRepeatable, bool isDone,
            DateTime schduledDate, int stationId, int userId)
        {


            TaskId = taskId;
            DateTime = dateTime;
            Description = description;
            IsRepeatable = isRepeatable;
            IsDone = isDone;
            SchduledDate = schduledDate;
            StationId = stationId;
            UserId = userId;
        }


        public TaskModel()
        {

        }
    }
}
