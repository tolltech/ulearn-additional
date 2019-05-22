using System;

namespace EncapsulationTask
{
    public class LogicStringBuilder : ILogicStringBuilder
    {
        //Представьте, что вам понадобился логинческий стрингбилдер,
        //который умеет добавлять строки в конец только при выоплнении каких-то условий
        //можно усложнить методами типа And() Or() и их комбинациями
        //постарайтесь использовать меньше памяти
        public LogicStringBuilder(string str)
        {
            
        }

        public ILogicStringBuilder IfEndsWith(string str)
        {
            throw new NotImplementedException();
        }

        public ILogicStringBuilder IfStartsWith(string str)
        {
            throw new NotImplementedException();
        }

        public ILogicStringBuilder Append(string str)
        {
            throw new NotImplementedException();
        }

        public ILogicStringBuilder AddToStart(string str)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            throw new NotImplementedException();
        }
    }
}