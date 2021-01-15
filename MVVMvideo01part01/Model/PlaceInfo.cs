using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace MVVMvideo01part01.Model
{
    internal class PlaceInfo
    {
        public string Name { get; set; }

        public Point Location { get; set; }

        public IEnumerable<ConfimedCount> Counts { get; set; }

    }
}
