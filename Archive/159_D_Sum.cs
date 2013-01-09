// http://codeforces.ru/contest/257/problem/D
﻿﻿﻿using System;
﻿﻿﻿using System.Collections.Generic;
﻿﻿﻿using System.IO;
﻿﻿﻿using System.Linq;
﻿﻿﻿using System.Text;

namespace CF {
    class Program {

        static void Main(string[] args) {

#if DEBUG
            TextReader reader = new StreamReader("../../input.txt");
            TextWriter writer = Console.Out;
#else
			TextReader reader = Console.In;
            TextWriter writer = Console.Out;
#endif

            var n = reader.Read<int>();
            var a = reader.ReadArr<int>()
                .SelectIndexes().ToArray();


#if DEBUG
            Console.ReadKey();
#endif
        }

    }


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
        public static IEnumerable<Pair<T, int>> SelectIndexes<T>(this IEnumerable<T> collection) {
            return collection.Select((v, i) => new Pair<T, int>(v, i));
        }
    }

}

