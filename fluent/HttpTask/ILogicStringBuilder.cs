namespace EncapsulationTask
{
    public interface ILogicStringBuilder
    {
        ILogicStringBuilder IfEndsWith(string str);
        ILogicStringBuilder IfStartsWith(string str);
        ILogicStringBuilder Append(string str);
        ILogicStringBuilder AddToStart(string str);
    }
}