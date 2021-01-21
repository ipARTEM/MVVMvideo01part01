using System;
using System.Collections.Generic;
using System.Text;

namespace MVVMvideo03part03.Models
{
    internal class CountryInfo : PlaceInfo
    {
        public IEnumerable<ProvinceInfo> ProvinceCounts { get; set; }
    }
}
