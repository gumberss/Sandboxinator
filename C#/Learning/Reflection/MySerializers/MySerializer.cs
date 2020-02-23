using System;

namespace Learning.Reflection.MySerializers
{
    public class MySerializer
    {
        public String Serialize<T>(T obj, IMySerializer serializer)
        {
            return serializer.Serialize(obj);
        }

    }
}
