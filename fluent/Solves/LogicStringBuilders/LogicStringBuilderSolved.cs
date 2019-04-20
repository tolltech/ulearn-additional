using System;
using System.Collections.Generic;
using System.Linq;
using EncapsulationTask;

namespace Solves.LogicStringBuilders
{
    //todo: можно усложнить методами типа And() Or() и их комбинациями
    //todo: кажется придется тогда выделять второй интерфейс
    public class LogicStringBuilderSolved : ILogicStringBuilder
    {
        private readonly string str;

        private readonly Func<string, bool> predicateFunc;
        private readonly Func<string, string> processFunc;

        private readonly List<LogicStringBuilderSolved> builders;

        public LogicStringBuilderSolved(string str)
        {
            this.str = str;
            builders = new List<LogicStringBuilderSolved> {this};
        }

        private LogicStringBuilderSolved(List<LogicStringBuilderSolved> builders, Func<string, bool> predicateFunc)
        {
            this.builders = builders;
            this.predicateFunc = predicateFunc;
            this.builders.Add(this);
        }

        private LogicStringBuilderSolved(List<LogicStringBuilderSolved> builders, Func<string, string> processFunc)
        {
            this.builders = builders;
            this.processFunc = processFunc;
            this.builders.Add(this);
        }

        public ILogicStringBuilder IfEndsWith(string str)
        {
            return new LogicStringBuilderSolved(builders, x => x.EndsWith(str));
        }

        public ILogicStringBuilder IfStartsWith(string str)
        {
            return new LogicStringBuilderSolved(builders, x => x.StartsWith(str));
        }

        public ILogicStringBuilder Append(string str)
        {
            return new LogicStringBuilderSolved(builders, x => x + str);
        }

        public ILogicStringBuilder AddToStart(string str)
        {
            return new LogicStringBuilderSolved(builders, x => str + x);
        }

        public override string ToString()
        {
            if (str != null)
            {
                return str;
            }

            var currentString = builders[0].str;
            bool? previousPredicate = null;
            foreach (var logicSB in builders.Skip(1))
            {
                if (logicSB.predicateFunc != null)
                {
                    previousPredicate = logicSB.predicateFunc.Invoke(currentString);
                    continue;
                }


                if (previousPredicate ?? true)
                {
                    currentString = logicSB.processFunc.Invoke(currentString);
                }

                previousPredicate = null;
            }

            return currentString;
        }
    }
}