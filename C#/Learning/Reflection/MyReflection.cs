using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Learning.Reflection
{
    public class MyReflection
    {
        public void Process()
        {
            Console.WriteLine(Serialize(new MyObj()));
            Console.WriteLine(Serialize(new MySerializableObj()));
            Console.WriteLine();
            Console.WriteLine(FirstAttrCondiction(new MyObj()));
            Console.WriteLine(FirstAttrCondiction(new MySerializableObj()));
            Console.WriteLine(FirstAttrCondiction(new MyReflection()));
        }

        public String Serialize<T>(T obj)
        {
            if (Attribute.IsDefined(typeof(T), typeof(SerializableAttribute)))
            {
                return "Ok! I did it :D";
            }

            return "Oh no!! I can't do this!";
        }

        public String FirstAttrCondiction<T>(T obj)
        {
            var firstAttr = obj.GetType().GetCustomAttributes(false).FirstOrDefault()?.GetType() ?? obj.GetType();

            return firstAttr switch
            {
                { Name: "SerializableAttribute" } => "Ok, I'll serialize it",
                { Name: "MyLittleAttrAttribute" } => "Ok, I'll, ..., ammm, ok, I got it... but I don't know exactly what to do",
                _ => "I don't know what you want me to do"
            };
        }
    }

    [MyLittleAttr]
    public class MyObj
    {

    }

    [Serializable]
    public class MySerializableObj
    {

    }

    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class MyLittleAttrAttribute : Attribute
    {

    }
}
