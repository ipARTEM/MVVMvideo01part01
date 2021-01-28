﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows;
using System.Windows.Data;

namespace MVVMvideo04part04.Infrastructure.Converters
{
    internal class LocationPointToStr : IValueConverter
    {
        public object Convert(object value, Type t, object p, CultureInfo c)
        {
            //var point = (Point)value;
            if (!(value is Point point)) return null;


            return $"Lat:{point.X}; Lon:{point.Y}";
        }

        public object ConvertBack(object value, Type y, object p, CultureInfo c)
        {
            //var str = (string)value;

            if (!(value is string str)) return null;

            var components = str.Split(';');
            var lat_str = components[0].Split(':')[1];
            var lot_str = components[1].Split(':')[1];

            var lat = double.Parse(lat_str);
            var lon = double.Parse(lot_str);

            return new Point(lat, lon);
        }
    }
}
