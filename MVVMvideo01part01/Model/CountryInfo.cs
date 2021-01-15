using System;
using System.Collections.Generic;
using System.Text;

namespace MVVMvideo01part01.Model
{
    internal class CountryInfo : PlaceInfo
    {
        public IEnumerable<ProvinceInfo> ProvinceCounts { get; set; }
    }
}
