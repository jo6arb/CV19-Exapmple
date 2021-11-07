using System.Collections.Generic;
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

        private ConfirmedCount[] _counts;
        private IEnumerable<ConfirmedCount> _counts1;

        public override IEnumerable<ConfirmedCount> Counts
        {
            get
            {
                if (_counts != null) return _counts;
                var pointsCount = ProvinceCounts.FirstOrDefault()?.Counts?.Count() ?? 0;
                if (pointsCount == 0) return Enumerable.Empty<ConfirmedCount>();

                var provincePoints = ProvinceCounts.Select(p => p.Counts.ToArray()).ToArray();

                var points = new ConfirmedCount[pointsCount];
                foreach (var province in provincePoints)
                    for (var i = 0; i < pointsCount; i++)
                    {
                        if (points[i].Date == default)
                            points[i] = province[i];
                        else
                            points[i].Count += province[i].Count;
                    }

                return _counts = points;
            }
            set => _counts1 = value;
        }
    }
}
