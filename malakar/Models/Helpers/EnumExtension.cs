using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace malakar.Models.Helpers
{
    public static class EnumExtensions
    {
        public static List<EnumValue> GetValues<T>()
        {
            List<EnumValue> values = new List<EnumValue>();
            foreach (var itemType in Enum.GetValues(typeof(T)))
            {
                //For each value of this enumeration, add a new EnumValue instance
                values.Add(new EnumValue()
                {
                    Id = (int)itemType,
                    Name = Enum.GetName(typeof(T), itemType)
                });
            }
            return values;
        }
    }
}