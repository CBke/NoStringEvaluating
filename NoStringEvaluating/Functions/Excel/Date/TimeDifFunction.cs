﻿using NoStringEvaluating.Factories;
using NoStringEvaluating.Functions.Base;
using NoStringEvaluating.Models.Values;
using System.Collections.Generic;

namespace NoStringEvaluating.Functions.Excel.Date
{
    /// <summary>
    /// Calculates the number of hours, minutes, or seconds between two dates
    /// <para>TimeDif(dateTime1; dateTime2; 'H'), can be: H, M, S</para>
    /// </summary>
    public class TimeDifFunction : IFunction
    {
        /// <summary>
        /// Name
        /// </summary>
        public virtual string Name { get; } = "TIMEDIF";

        /// <summary>
        /// Execute value
        /// </summary>
        public InternalEvaluatorValue Execute(List<InternalEvaluatorValue> args, ValueFactory factory)
        {
            var dateStart = args[0].GetDateTime();
            var dateEnd = args[1].GetDateTime();
            var format = args[2].GetWord().ToUpperInvariant();

            if (dateStart > dateEnd)
            {
                return double.NaN;
            }

            if (format == "H")
            {
                return dateEnd.Subtract(dateStart).TotalHours;
            }

            if (format == "M")
            {
                return dateEnd.Subtract(dateStart).TotalMinutes;
            }

            if (format == "S")
            {
                return dateEnd.Subtract(dateStart).TotalSeconds;
            }

            return double.NaN;
        }
    }
}
