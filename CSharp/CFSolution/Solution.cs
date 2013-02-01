﻿﻿﻿﻿using System;
﻿﻿﻿using System.Collections.Generic;
﻿﻿﻿﻿using System.Globalization;
﻿﻿﻿﻿using System.IO;
﻿﻿﻿using System.Linq;
﻿﻿﻿using System.Text;
﻿﻿﻿﻿using System.Threading;

namespace CF {

    

    class Program {

        static HashSet<int> possibleAngles; 

        static void Main(string[] args) {

            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

#if DEBUG
            TextReader reader = new StreamReader("../../input.txt");
            TextWriter writer = Console.Out;
#else
			TextReader reader = Console.In;
            TextWriter writer = Console.Out;
#endif

            possibleAngles = new HashSet<int>();
            var n = reader.Read<int>();

            for (int i = 2; i < 180; i++) {
                if((180 % i) == 0){
                    var outAngl = 180 - (180 / i);
                    if ((360 % outAngl) == 0)
                        possibleAngles.Add(180 / i);
                }
            }

            for (int i = 0; i < n; i++) {
                var a = reader.Read<int>();
                if(possibleAngles.Contains(a)){
                    Console.WriteLine("YES");
                }
                else {
                    Console.WriteLine("NO");
                }
            }
            

#if DEBUG
            Console.ReadKey();
#endif
        }

        

    }


    #region template
    class Pair<T1, T2> {
        public Pair(T1 first, T2 second) {
            First = first;
            Second = second;
        }
        public T1 First { get; set; }
        public T2 Second { get; set; }
        public override string ToString() {
            return "{" + First + " " + Second + "}";
        }
        
    }

    static class ReaderExtensions {

        public static string ReadToken(this TextReader reader) {
            int val;
            var builder = new StringBuilder();
            while (true) {
                val = reader.Read();
                if (val == ' ' || val == -1) {
                    if (builder.Length == 0) continue;
                    break;
                }
                if (val == 13) {
                    reader.Read();
                    if (builder.Length == 0) continue;
                    break;
                }
                builder.Append((char)val);
            }
            return builder.ToString();
        }

        public static T Read<T>(this TextReader reader) {
            return (T)Convert.ChangeType(reader.ReadToken(), typeof(T));
        }

        public static T[] ReadArr<T>(this TextReader reader) {
            return reader.ReadLine()
                .Split(' ').Select(str =>
                    (T)Convert.ChangeType(str, typeof(T))
                ).ToArray();
        }

    }

    static class LinqExtensions {
        /// <summary>Value / Index</summary>
        public static IEnumerable<Pair<T, int>> SelectIndexes<T>(this IEnumerable<T> collection) {
            return collection.Select((v, i) => new Pair<T, int>(v, i));
        }
        public static IEnumerable<T> SelectValues<T>(this IEnumerable<Pair<T, int>> collection) {
            return collection.Select(p => p.First);
        }
        public static void AddRepeatedRange<T, V>(this IDictionary<T, ICollection<V>> dictionary, 
            Func<ICollection<V>> generator, IEnumerable<Pair<T,V>> sourceCollection ) {
            foreach (var pair in sourceCollection) {
                if (!dictionary.ContainsKey(pair.First)) {
                    dictionary[pair.First] = generator();
                }
                dictionary[pair.First].Add(pair.Second);
            }
        }
        public static T Second<T>(this IEnumerable<T> collection) {
            return collection.Skip(1).First();
        }
    }

    static class OutputExtensions {
        public static void WriteBySeparatorLine<T>(this IEnumerable<T> list, string sep = " ") {
            foreach (var v in list) {
                Console.Write(v);
                Console.Write(sep);
            }
            Console.WriteLine();
        }
    }

    #endregion 
}