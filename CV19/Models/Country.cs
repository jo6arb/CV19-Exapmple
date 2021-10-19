using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows;

namespace CV19.Models
{
    internal class PlaceInfo    
    {
        public string Name { get; set; }

        public Point Location { get; set; }
    }

    internal class CountryInfo : PlaceInfo
    {
        public IEnumerable<ProvinceInfo> ProvinceCounts { get; set; }
    }

    internal class ProvinceInfo : PlaceInfo {}

    internal struct ConfirmedCount
    {
        public DateTime Date { get; set; }
        public int Count { get; set; }
    }



}