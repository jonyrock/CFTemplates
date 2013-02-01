// http://codeforces.ru/contest/257/problem/D
using System;
﻿﻿﻿using System.Collections.Generic;
﻿﻿﻿using System.IO;
﻿﻿﻿using System.Linq;
﻿﻿﻿using System.Text;

namespace CF {
    class Program {

        static int N;
        static int M;

        static void Main(string[] args) {

#if DEBUG
            TextReader reader = new StreamReader("../../input.txt");
            TextWriter writer = Console.Out;
#else
			TextReader reader = Console.In;
            TextWriter writer = Console.Out;
#endif
            var n = reader.Read<int>();
            var a = reader.ReadArr<int>();

            var signMap = new Stack<bool>();

            var rightSum = a[n-1];
            var i = n - 2;
            while (i >= 0) {
                rightSum = rightSum - a[i];
                if (rightSum < 0) {
                    signMap.Push(false);
                    rightSum = -rightSum;
                } else
                    signMap.Push(true);
                i--;
            }
            var invert = false;
            while (signMap.Any()) {
                var val = signMap.Pop();
                var wasInvert = invert;
                if (!val)
                    invert = !invert;
                if (wasInvert) val = !val;
                Console.Write(val ? "-" : "+");
            }

            Console.Write(invert ? "-" : "+");

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
                if (val == ' ' || val == -1){ 
                    if(builder.Length == 0) continue;
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

}

