﻿using System.Collections.Generic;
using NoStringEvaluating.Factories;
using NoStringEvaluating.Functions.Base;
using NoStringEvaluating.Models.Values;

namespace NoStringEvaluating.Functions.Math.Trigonometry.Tan
{
    /// <summary>
    /// Function - arctanh
    /// </summary>
    public class ArctanhFunction : IFunction
    {
        /// <summary>
        /// Name
        /// </summary>
        public virtual string Name { get; } = "ARCTANH";

        /// <summary>
        /// Evaluate value
        /// </summary>
        public InternalEvaluatorValue Execute(List<InternalEvaluatorValue> args, ValueFactory factory)
        {
            return System.Math.Atanh(args[0]);
        }
    }
}
