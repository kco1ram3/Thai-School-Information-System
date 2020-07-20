using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iSISModel
{
    public class StudentTimeAttendance : PersistentTemporalEntity64
    {
        public virtual string FingerScannerID { get; set; }
        public virtual Student Student { get; set; }
        public virtual DateTime TimeAttendanceDate { get; set; }
        public virtual DateTimeRange TimeAttendancePeriod { get; set; }
    }
}
