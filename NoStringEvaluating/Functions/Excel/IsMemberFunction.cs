﻿using NoStringEvaluating.Factories;
using NoStringEvaluating.Functions.Base;
using NoStringEvaluating.Models.Values;
using System.Collections.Generic;

namespace NoStringEvaluating.Functions.Excel
{
    /// <summary>
    /// IsMember(myList; item)
    /// </summary>
    public class IsMemberFunction : IFunction
    {
        /// <summary>
        /// Name
        /// </summary>
        public virtual string Name { get; } = "ISMEMBER";

        /// <summary>
        /// Execute value
        /// </summary>
        public InternalEvaluatorValue Execute(List<InternalEvaluatorValue> args, ValueFactory factory)
        {
            var argList = args[0];
            var argItem = args[1];

            if (argList.IsWordList)
            {
                if(!argItem.IsWord) return 0;

                var wordList = argList.GetWordList();
                return wordList.Contains(argItem.GetWord()) ? 1 : 0;
            }

            if (argList.IsNumberList)
            {
                if(!argItem.IsNumber) return 0;

                var numberList = argList.GetNumberList();
                return numberList.Contains(argItem.Number) ? 1 : 0;
            }

            return 0;
        }
    }
}
