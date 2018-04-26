using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StationLogFinal.Model
{
  public  class Task
    {
        public int _TaskId { get; set; }

        public DateTime _DateTime { get; set; }

  
        public string _Description { get; set; }

        public bool _IsRepeatable { get; set; }

        public bool _IsDone { get; set; }

        public DateTime _SchduledDate { get; set; }

        public int _StationId { get; set; }

        public int _UserId { get; set; }



        public Task(int TaskId, DateTime DateTime, string Description, bool IsRepeatable, bool IsDone,
            DateTime SchduledDate, int StationId, int UserId)
        {
            _TaskId = TaskId;
            _DateTime = DateTime;
            _Description = Description;
            _IsRepeatable = IsRepeatable;
            _IsDone = IsDone;
            _SchduledDate = SchduledDate;
            _StationId = StationId;
            _UserId = UserId;
        }

        public Task()
        {

        }

        public override string ToString()
        {
            return string.Format("", _TaskId, _DateTime, _Description, _IsRepeatable, _IsDone, _SchduledDate,
                _StationId, _UserId);
        }
    }
}
