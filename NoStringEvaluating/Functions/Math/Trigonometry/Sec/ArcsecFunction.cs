﻿using System.Collections.Generic;
using NoStringEvaluating.Factories;
using NoStringEvaluating.Functions.Base;
using NoStringEvaluating.Models.Values;
using static System.Math;

namespace NoStringEvaluating.Functions.Math.Trigonometry.Sec
{
    /// <summary>
    /// Function - arcsec
    /// </summary>
    public class ArcsecFunction : IFunction
    {
        /// <summary>
        /// Name
        /// </summary>
        public virtual string Name { get; } = "ARCSEC";

        /// <summary>
        /// Evaluate value
        /// </summary>
        public InternalEvaluatorValue Execute(List<InternalEvaluatorValue> args, ValueFactory factory)
        {
            var x = args[0];

            // 2 * Atan(1) == 1.5707963267948966
            return 1.5707963267948966 - Atan(Sign(x) / Sqrt(x * x - 1));
        }
    }
}
