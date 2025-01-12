﻿using System.Collections.Generic;
using NoStringEvaluating.Factories;
using NoStringEvaluating.Functions.Base;
using NoStringEvaluating.Models.Values;
using static System.Math;

namespace NoStringEvaluating.Functions.Math.Trigonometry.Cosec
{
    /// <summary>
    /// Function - arccsch
    /// </summary>
    public class ArccschFunction : IFunction
    {
        /// <summary>
        /// Name
        /// </summary>
        public virtual string Name { get; } = "ARCCSCH";

        /// <summary>
        /// Evaluate value
        /// </summary>
        public InternalEvaluatorValue Execute(List<InternalEvaluatorValue> args, ValueFactory factory)
        {
            var x = args[0];
            var a = Sign(x) * Sqrt(x * x + 1) + 1;
            return Log(a / x);
        }
    }
}
