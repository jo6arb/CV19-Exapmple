﻿using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace CV19.Models
{
    internal class CountryInfo : PlaceInfo
    {

        private Point _location;

        public override Point Location
        {
            get
            {

                if (ProvinceCounts is null) return default;

                var averageX = ProvinceCounts.Average(p => p.Location.X);
                var averageY = ProvinceCounts.Average(p => p.Location.Y);

                return _location = new Point(averageX, averageY);
            }
            set => _location = value;
        }

        public IEnumerable<PlaceInfo> ProvinceCounts { get; set; }
    }
}