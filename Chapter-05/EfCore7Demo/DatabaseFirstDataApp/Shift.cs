using System;
using System.Collections.Generic;

namespace DatabaseFirstDataApp
{
    public partial class Shift
    {
        public int ShiftId { get; set; }
        public int WeekDay { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public int FactoryId { get; set; }
        public int EmployeeId { get; set; }

        public virtual Employee Employee { get; set; } = null!;
        public virtual Factory Factory { get; set; } = null!;
    }
}
