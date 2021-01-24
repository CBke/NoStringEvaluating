﻿using System.Collections.Generic;
using NoStringEvaluating.Functions.Base;

namespace NoStringEvaluating.Functions.Math.Trigonometry.Cotan
{
    /// <summary>
    /// Function - actg
    /// </summary>
    public class ActgFunction : IFunction
    {
        /// <summary>
        /// Name
        /// </summary>
        public virtual string Name { get; } = "ACTG";

        /// <summary>
        /// Evaluate value
        /// </summary>
        public double Execute(List<double> args)
        {
            // Math.PI / 2 == 1.5707963267948966
            return 1.5707963267948966 - System.Math.Atan(args[0]);
        }
    }
}
