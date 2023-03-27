using System;
using System.Collections.Generic;

namespace DatabaseFirstDataApp
{
    public partial class Factory
    {
        public Factory()
        {
            Shifts = new HashSet<Shift>();
        }

        public int FactoryId { get; set; }
        public string FactoryName { get; set; } = null!;
        public string Location { get; set; } = null!;

        public virtual ICollection<Shift> Shifts { get; set; }
    }
}
