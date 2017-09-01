using MyConfig;

namespace ConsoleApp1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var vp = Config.GetValuePair("LogName");

            if (vp == null)
                Config.SetValuePair(new ValuePair {Name = "LogName", Value = "Log.txt"});

            vp = Config.GetValuePair("LogName");
        }
    }
}