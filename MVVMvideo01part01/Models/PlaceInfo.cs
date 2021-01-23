using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace MVVMvideo04part04.Models
{
    internal class PlaceInfo
    {
        public string Name { get; set; }

        public virtual Point Location { get; set; }

        //public virtual IEnumerable<ConfirmedCount> Counts { get; set; }

        public override string ToString() => $"{Name}({Location})";

    }
}
