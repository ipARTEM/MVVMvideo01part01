﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Data;
using System.Windows.Markup;

namespace MVVMvideo04part04.Infrastructure.Converters
{

    /// <summary>
    /// Реализация преобразования f(x)=k*x+b
    /// </summary>
    [ValueConversion(typeof(double), typeof(string))]
    internal class Linear : Converter
    {
        [ConstructorArgument("K")]
        public double K { get; set; } = 1;

        [ConstructorArgument("B")]
        public double B { get; set; }

        public Linear() { }

        public Linear(double K)
        {
            this.K = K;
        }

        public Linear(double K, double B):this (K)
        {
            this.B = B;
        }

        public override object Convert(object v, Type t, object p, CultureInfo c)
        {
            if (v is null) return null;

            var x = System.Convert.ToDouble(v, c);
            return K * x + B;
        }

        public override object ConvertBack(object v, Type t, object p, CultureInfo c)
        {
            if (v is null) return null;

            var y = System.Convert.ToDouble(v, c);

            return (y - B) / K;
        }
    }
}
