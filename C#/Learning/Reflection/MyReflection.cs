using System;
using System.Collections.Generic;
using System.Text;

namespace Learning.Reflection
{
    public class MyReflection
    {
        public void Process()
        {
            Console.WriteLine(Serialize(new MyObj()));
            Console.WriteLine(Serialize(new MySerializableObj()));
        }

        public String Serialize<T>(T obj)
        {
            if (Attribute.IsDefined(typeof(T), typeof(SerializableAttribute)))
            {
                return "Ok! I did it :D";
            }

            return "Oh no!! I can't do this!";

        }

    }

    public class MyObj
    {

    }

    [Serializable]
    public class MySerializableObj
    {

    }
}
