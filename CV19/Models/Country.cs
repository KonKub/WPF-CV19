using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace CV19.Models
{
    internal class PlaceInfo
    {
        public string Name { get; set; }
        public Point Location { get; set; }
        public IEnumerable<ConfirmedCout> Counts { get; set; }
    }

    internal class CountryInfo : PlaceInfo
    {
        public IEnumerable<ProvinceInfo> ProvinceCounts { get; set; }
    }

    internal class ProvinceInfo : PlaceInfo
    {

    }

    internal struct ConfirmedCout
    {
        public DateTime Date { get; set; }
        public int Count { get; set; }
    }

    internal struct DataPoint
    {
        public double XValue { get; set; }
        public double YValue { get; set; }
    }
}
