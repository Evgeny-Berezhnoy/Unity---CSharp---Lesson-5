using System;
using System.Collections.Generic;
using System.Linq;

namespace Berezhnoy.Extensions
{
    public static class ExtensionMethods
    {

        public static int SymbolsQuantity(this string self)
        {

            return self.Length;

        }

        public static Dictionary<T1, T2> Clone<T1, T2>(this Dictionary<T1, T2> dictionaryToClone) 
        {

            var dictionary = new Dictionary<T1, T2>();

            foreach (KeyValuePair<T1, T2> keyValuePair in dictionaryToClone)
            {

                dictionary.Add(keyValuePair.Key, keyValuePair.Value);

            };

            return dictionary;

        }

    }

}
