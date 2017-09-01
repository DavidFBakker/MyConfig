using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace MyConfig
{
    // Super cool. I now have a class where i can store name=values in.
    // ValuePairs:List<ValuePair> Basically it turns your ValuePair class into a List 
    public class ValuePairs : List<ValuePair>
    {
    }

    public class ValuePair
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }

    public static class Config
    {
        public static ValuePair GetValuePair(string name)
        {
            var vp = ValuePairs();
            var value = vp.SingleOrDefault(a => a.Name == name);
            return value;
        }

        public static void SetValuePair(ValuePair valuePair)
        {
            var vp = ValuePairs();
            var value = vp.SingleOrDefault(a => a.Name == valuePair.Name);

            if (value != null) //Exists lets just update the value
                value.Name = valuePair.Name;
            else
                vp.Add(valuePair);

            var towrite = JsonConvert.SerializeObject(vp);

            File.WriteAllText("configFile.json", towrite);
        }

        private static ValuePairs ValuePairs()
        {
            var input = File.ReadAllText("configFile.json");
            var valuePairs = JsonConvert.DeserializeObject<ValuePairs>(input);
            return valuePairs;
        }
    }
}