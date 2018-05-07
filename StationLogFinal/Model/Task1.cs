using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using StationLogFinal.ViewModel;

namespace StationLogFinal.Model
{
    public partial class Task1:NotifyPropertyChange
    {
        private DateTimeOffset _date;
        private DateTime _dateTime;

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
   
        public int TaskId { get; set; }

        public DateTime DateTime { get => _dateTime; set => _dateTime = value; }

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
        public Task1(int taskId, DateTime dateTime, string description, bool isRepeatable, bool isDone,
            DateTime schduledDate, int stationId, int userId)
        {
            DateTime dt = System.DateTime.Now;

            _date = new DateTimeOffset(dt.Year, dt.Month, dt.Day, 0, 0, 0, 0, new TimeSpan());

            TaskId = taskId;
            DateTime = dateTime;
            Description = description;
            IsRepeatable = isRepeatable;
            IsDone = isDone;
            SchduledDate = schduledDate;
            StationId = stationId;
            UserId = userId;
        }
        public Task1()
        {

        }
        public DateTimeOffset Date
        {
            get => _date;


            set
            {
                _date = value;
                OnPropertyChanged(nameof(Date));
            }
        }
        //public override string ToString()
        //{
        //    return string.Format("TaskId {0} DateTime {1} Description {2}  IsRepeatable {3} IsDone{4} SchduledDate{5} StationId{6} UserId{7}",
        //        TaskId, DateTime, Description, IsRepeatable, IsDone, SchduledDate, StationId, UserId);

        //}
    }
}
