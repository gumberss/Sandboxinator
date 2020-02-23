using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Learning.Reflection.MySerializers
{
    public class MyXmlSerializer : IMySerializer
    {
        public string Serialize<T>(T obj)
        {
            var builder = new StringBuilder();

            Serialize(obj, builder);

            return builder.ToString();
        }

        private void Serialize<T>(T obj, StringBuilder builder, int depth = 0, String propertyName = null)
        {
            if (obj == null) return;

            var properties = obj.GetType().GetProperties();

            builder
                .Append('\t', depth)
                .Append('<').Append(propertyName ?? obj.GetType().Name).Append('>')
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
                       .Append('<').Append(property.Name).Append('>')
                       .AppendLine();

                    foreach (var item in list)
                    {
                        Serialize(item, builder, depth + 2);
                    }

                    builder
                       .Append('\t', depth + 1)
                       .Append("</").Append(property.Name).Append('>')
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
                        .Append('<').Append(property.Name).Append('>')
                        .Append(property.GetValue(obj))
                        .Append("</").Append(property.Name).Append('>')
                        .AppendLine();
                }
            }

            builder
                .Append('\t', depth)
                .Append("</").Append(propertyName ?? obj.GetType().Name).Append('>')
                .AppendLine();
        }
    }
}
