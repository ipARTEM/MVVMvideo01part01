using System;
using System.Collections.Generic;
using System.Text;

namespace MVVMvideo04part04.Models
{
    internal class CountryInfo : PlaceInfo
    {
        public IEnumerable<ProvinceInfo> ProvinceCounts { get; set; }
    }
}
