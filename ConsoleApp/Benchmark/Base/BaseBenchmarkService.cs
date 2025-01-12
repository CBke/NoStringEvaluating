﻿using System;
using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;
using Microsoft.Extensions.DependencyInjection;
using NoStringEvaluating;
using NoStringEvaluating.Contract;
using NoStringEvaluating.Extensions;
using NoStringEvaluating.Extensions.Microsoft.DependencyInjection;
using NoStringEvaluating.Factories;
using NoStringEvaluating.Functions.Base;
using NoStringEvaluating.Models.Values;
using org.mariuszgromada.math.mxparser;

namespace ConsoleApp.Benchmark.Base
{
    [MemoryDiagnoser]
    [SimpleJob(RunStrategy.Monitoring, warmupCount: 2, invocationCount: 3, targetCount: 3)]
    public abstract class BaseBenchmarkService
    {
        public virtual int N { get; set; } = 1_000_000;

        #region NoString

        protected virtual void CalcNoString(string formula, params string[] argsNames)
        {
            var eval = CreateNoString();
            var args = argsNames.ToDictionary(s => s, r => (EvaluatorValue)1.7);

            eval.CalcNumber(formula, args);

            for (var i = 0; i < N; i++)
            {
                eval.CalcNumber(formula, args);
            }
        }

        protected virtual void CalcNoString(string formula)
        {
            var eval = CreateNoString();
            eval.CalcNumber(formula);

            for (var i = 0; i < N; i++)
            {
                eval.CalcNumber(formula);
            }
        }

        protected INoStringEvaluator CreateNoString()
        {
            var container = new ServiceCollection().AddNoStringEvaluator();
            var services = container.BuildServiceProvider();

            var functionReader = services.GetRequiredService<IFunctionReader>();
            NoStringFunctionsInitializer.InitializeFunctions(functionReader, typeof(BaseBenchmarkService));

            return services.GetRequiredService<INoStringEvaluator>();
        }

        #endregion

        #region MxParser

        protected void CalcMxParser(string formula, params string[] argsNames)
        {
            var expression = CreateMxParser(formula);

            for (var i = 0; i < argsNames.Length; i++)
            {
                expression.defineArgument(argsNames[i], 1.7);
            }

            expression.calculate();

            for (var i = 0; i < N; i++)
            {
                expression.calculate();
            }
        }

        protected void CalcMxParser(string formula)
        {
            var expression = CreateMxParser(formula);

            expression.calculate();

            for (var i = 0; i < N; i++)
            {
                expression.calculate();
            }
        }

        private Expression CreateMxParser(string formula)
        {
            var expression = new Expression(formula);

            var f1 = new Function("kov", new FExtension_kov());
            var f2 = new Function("kovt", new FExtension_kovt());
            expression.addFunctions(f1, f2);

            return expression;
        }

        #endregion

        public const string Arg1 = "arg1";
        public const string Arg2 = "arg2";
        public const string Arg3 = "arg3";
        public const string Arg4 = "arg4";
        public const string Arg5 = "arg5";
        public const string Arg6 = "arg6";
        public const string Arg7 = "arg7";
        public const string Arg8 = "arg8";
        public const string Arg9 = "arg9";
        public const string Arg10 = "arg10";

        public static string Empty = "";
        public static string NumberOnly = "3";
        public static string Formula1 = "3 * 9";
        public static string Formula2 = "3 * 9 / 456 * 32 + 12 / 17 - 3";
        public static string Formula3 = "3 * (9 / 456 * (32 + 12)) / 17 - 3";
        public static string Formula4 = "(2 + 6 - (13 * 24 + 5 / (123 - 364 + 23))) - (2 + 6 - (13 * 24 + 5 / (123 - 364 + 23))) + (2 + 6 - (13 * 24 + 5 / (123 - 364 + 23))) * 345 * ((897 - 323)/ 23)";

        public static string Formula5 = $"{Arg1} * {Arg2} + {Arg3} - {Arg4}";
        public static string Formula6 = $"{Arg1} * ({Arg2} + {Arg3}) - {Arg4} / ({Arg5} - {Arg6}) + 45 * {Arg7} + (({Arg8} * 56 + (12 + {Arg9}))) - {Arg10}";

        public static string Formula7 = $"add(1; 2; 3)";
        public static string Formula8 = $"add(add(5; 1) - add(5; 2; 3))";
        public static string Formula9 = $"if({Arg1}; add(56 + 9 / 12 * 123.596; or(78; 9; 5; 2; 4; 5; 8; 7); 45;5); 9) *     24 + 52 -33";
        public static string Formula10 = $"kov(1; 2; 3) - kovt(8; 9)"; // 6 - -1 = 7
    }

    #region CustomFunctions

    public class Func_kov : IFunction
    {
        public string Name { get; } = "kov";

        public InternalEvaluatorValue Execute(List<InternalEvaluatorValue> args, ValueFactory factory)
        {
            var res = 1d;

            for (int i = 0; i < args.Count; i++)
            {
                res *= args[i];
            }

            return res;
        }
    }

    public class Func_kovt : IFunction
    {
        public string Name { get; } = "kovt";

        public InternalEvaluatorValue Execute(List<InternalEvaluatorValue> args, ValueFactory factory)
        {
            return args[0] - args[1];
        }
    }

    //public class Func_kov : IFunction
    //{
    //    public string Name { get; } = "kov";

    //    public double Execute(List<double> args)
    //    {
    //        var res = 1d;

    //        for (int i = 0; i < args.Count; i++)
    //        {
    //            res *= args[i];
    //        }

    //        return res;
    //    }
    //}

    //public class Func_kovt : IFunction
    //{
    //    public string Name { get; } = "kovt";

    //    public double Execute(List<double> args)
    //    {
    //        return args[0] - args[1];
    //    }
    //}

    public class FExtension_kov : FunctionExtensionVariadic
    {
        public double calculate(params double[] parameters)
        {
            var res = 1d;

            for (int i = 0; i < parameters.Length; i++)
            {
                res *= parameters[i];
            }

            return res;
        }

        public FunctionExtensionVariadic clone()
        {
            throw new NotImplementedException();
        }
    }

    public class FExtension_kovt : FunctionExtensionVariadic
    {
        public double calculate(params double[] parameters)
        {
            return parameters[0] - parameters[1];
        }

        public FunctionExtensionVariadic clone()
        {
            throw new NotImplementedException();
        }
    }

    #endregion

}
