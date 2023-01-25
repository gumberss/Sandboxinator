using RecordsTesting.interfaces;
using RecordsTesting.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecordsTesting.logic
{
    public static class NameChanger
    {
        //this do not work with records so far
        public static T ChangeName<T>(T data, String otherName) where T : struct, INamed
        {
            return data with { Name = otherName };
        }

        public static T ChangeNameRecord<T>(T data, String otherName) where T : NamedRecord
        {
            return data with { Name = otherName };
        }
    }
}
