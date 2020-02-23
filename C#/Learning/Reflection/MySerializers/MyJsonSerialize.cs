using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Learning.Reflection.MySerializers
{
    class MyJsonSerialize : IMySerializer
    {
        public string Serialize<T>(T obj)
        {
            var builder = new StringBuilder();

            Serialize(obj, builder);

            return builder
                .Remove(builder.Length - 1, 1)
                .ToString();
        }

        private void Serialize<T>(T obj, StringBuilder builder, int depth = 0, String propertyName = null)
        {
            if (obj == null) return;

            var properties = obj.GetType().GetProperties();

            builder
                .Append('\t', depth)
                .Append('"').Append(propertyName ?? obj.GetType().Name).Append("\": {")
                .AppendLine();

            foreach (var property in properties)
            {
                if (property.PropertyType.IsGenericType && (property.PropertyType.GetGenericTypeDefinition() == typeof(List<>)))
                {
                    var listObj = property.GetValue(obj);

                    var list = (listObj as IEnumerable);

                    if (list == null) continue;

                    builder
                       .Append('\t', depth + 1)
                       .Append('"').Append(property.Name).Append("\": [")
                       .AppendLine();

                    foreach (var item in list)
                    {
                        Serialize(item, builder, depth + 2);
                    }

                    builder
                       .Remove(builder.Length - 3, 1)
                       .Append('\t', depth + 1)
                       .Append("],")
                       .AppendLine();
                }
                else if (property.PropertyType != typeof(String) && property.PropertyType.IsClass)
                {
                    Serialize(property.GetValue(obj), builder, depth + 1, property.Name);
                }
                else
                {
                    builder
                        .Append('\t', depth + 1)
                        .Append('"').Append(property.Name).Append("\": ");

                    if (property.PropertyType == typeof(String))
                        builder.Append('\"').Append(property.GetValue(obj)).Append('\"');
                    else
                        builder.Append(property.GetValue(obj));

                    builder
                        .Append(",")
                        .AppendLine();
                }
            }

            builder
                .Remove(builder.Length - 3, 1)
                .Append('\t', depth)
                .Append("},")
                .AppendLine();
        }
    }
}
