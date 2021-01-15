using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace MVVMvideo02part02.Models
{
    internal class PlaceInfo
    {
        public string Name { get; set; }

        public Point Location { get; set; }

        public IEnumerable<ConfimedCount> Counts { get; set; }

    }
}
