﻿using System.Collections.Generic;
using NoStringEvaluating.Exceptions;
using NoStringEvaluating.Models.Values;
using NoStringEvaluating.Services.Keepers.Base;

namespace NoStringEvaluating.Services.Keepers
{
    internal class NumberListKeeper : BaseValueKeeper<List<double>>
    {
        internal NumberListKeeper() : base(ValueTypeKey.NumberList)
        {

        }

        // Static 
        internal static NumberListKeeper Instance { get; }

        static NumberListKeeper()
        {
            Instance = new NumberListKeeper();
        }
    }
}
