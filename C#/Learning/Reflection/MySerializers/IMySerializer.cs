using System;

namespace Learning.Reflection.MySerializers
{
    public interface IMySerializer
    {
        String Serialize<T>(T obj);
    }
}
