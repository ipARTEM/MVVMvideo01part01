using System;
using System.Collections.Generic;
using System.Text;

namespace MVVMvideo02part02.Model
{
    internal class CountryInfo : PlaceInfo
    {
        public IEnumerable<ProvinceInfo> ProvinceCounts { get; set; }
    }
}
