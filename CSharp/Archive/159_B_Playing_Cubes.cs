// http://codeforces.ru/contest/257/problem/B
﻿﻿﻿﻿using System;
using System.IO;
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
            var m = reader.Read<int>();

            

            var game1 = 0;
            if (n > 0) {
                N = n;
                M = m;
                game1 = PetyaAttempt(true);
            }
            var game2 = 0;
            if (m > 0) {
                N = n;
                M = m;
                game2 = PetyaAttempt(false);
            }

            var p = Math.Max(game1,game2);
            var v = Math.Max(0, n + m - 1 - p);

            Console.WriteLine("{0} {1}", p, v);

#if DEBUG
            Console.ReadKey();
#endif
        }

        private static int PetyaAttempt(bool first){
            if (first) N--;
            if (!first) M--;
            bool prevColor = first;
            bool petyaTurn = false;
            int petyaCount = 0;

            while (N+M > 0) {
                bool next = Step(petyaTurn, prevColor);
                petyaTurn = !petyaTurn;
                if (prevColor == next) 
                    petyaCount++;
                if (next) N--;
                else M--;
                prevColor = next;
            }

            return petyaCount;
        }

        private static bool Step(bool isPetya, bool prevColor) {
            if (N == 0) {
                return false;
            }
            if (M == 0) {
                return true;
            }

            if (isPetya) {
                return prevColor;
            }
            return !prevColor;
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
