﻿using System;
using System.Collections.Generic;
using System.Text;
using NoStringEvaluating.Nodes.Common;

namespace NoStringEvaluating.Contract
{
    /// <summary>
    /// Parser from string to object sequence
    /// </summary>
    public interface IFormulaParser
    {
        /// <summary>
        /// Function reader
        /// </summary>
        IFunctionReader FunctionsReader { get; }

        /// <summary>
        /// Return parsed formula nodes
        /// </summary>
        FormulaNodes Parse(string formula);

        /// <summary>
        /// Return parsed formula nodes
        /// </summary>
        FormulaNodes Parse(ReadOnlySpan<char> formula);
    }
}
