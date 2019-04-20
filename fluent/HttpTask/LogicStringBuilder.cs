using System;

namespace EncapsulationTask
{
    public class LogicStringBuilder : ILogicStringBuilder
    {
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