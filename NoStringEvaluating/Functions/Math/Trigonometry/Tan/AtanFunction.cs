﻿using System.Collections.Generic;
using NoStringEvaluating.Factories;
using NoStringEvaluating.Functions.Base;
using NoStringEvaluating.Models.Values;

namespace NoStringEvaluating.Functions.Math.Trigonometry.Tan
{
    /// <summary>
    /// Function - atan
    /// </summary>
    public class AtanFunction : IFunction
    {
        /// <summary>
        /// Name
        /// </summary>
        public virtual string Name { get; } = "ATAN";

        /// <summary>
        /// Evaluate value
        /// </summary>
        public InternalEvaluatorValue Execute(List<InternalEvaluatorValue> args, ValueFactory factory)
        {
            return System.Math.Atan(args[0]);
        }
    }
}
