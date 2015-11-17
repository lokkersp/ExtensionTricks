using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace ExtensionTricks
{
    public static class ExtensionMethods
    {
        public static T[] CopyFirstN<T>(this T[] s,int n)
        {
            var rst = new T[n];
            for(int i = 0; i < n;i++)
            {
                rst[i] = s[i];
            }
            return rst;
        }
        public static T[] CopyLastN<T>(this T[] s, int n)
        {
            var l = s.Length;
            var rst = new T[n];
            for (int i = 0; i < n; i++) rst[i] = s[i + (l - n)];
            return rst;
        }

        public static bool AreEquals<T>(this T[] one,T[] other)
        {
            bool f = false;
            for(int i = 0; i < one.Length;i++)
            {
                if (one[i].Equals(other[i])) f = true;
                else { f = false;
                            break;
                }
            }
            return f;

        }
        public static List<string> StartsWith(this string[] names,string mask)
        {
            var result = new List<string>();
            var charA = mask.ToCharArray();
                foreach(string name in names)
            {
                var t = name.ToCharArray().CopyFirstN(charA.Length);
                if (t.AreEquals(charA)) result.Add(name);
              
            }

            return result;
        }
        public static List<string> EndsWith(this string[] names, string mask)
        {
            var result = new List<string>();
            var charA = mask.ToCharArray();
            foreach (string name in names)
            {
                var t = name.ToCharArray().CopyLastN(charA.Length);
                if (t.AreEquals(charA)) result.Add(name);
            }
            return result;
        }
        public static List<string> StartsWithRE(this string[] fileNames, string mask)
        {
            var result = new List<string>();
            Regex r = new Regex(@"^"+mask+@"\w*");
            foreach (string name in fileNames)
            {
                if (r.IsMatch(name)) result.Add(name);
            }
            return result;
        }

        public static List<string> EndsWithRE(this string[] fileNames, string mask)
        {
            var result = new List<string>();
            Regex r = new Regex(@".*" + mask+@"$");
            foreach (string name in fileNames)
            {
                if (r.IsMatch(name)) result.Add(name);
            }
            return result;
        }

        public static string printList<T>(this IList<T> list)
        {
            var s = string.Empty;
            foreach (T obj in list) s += obj.ToString() + "\n";
            return s;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            

            Console.WriteLine("stars with \'V\' in [Veni,Vidi,Vichi]");
            Console.WriteLine((new string[] { "Veni", "Vidi", "Vichi" }).StartsWithRE("V").printList());

            Console.WriteLine("stars with \'Ve\' in [Veni,Vidi,Vichi]");
            Console.WriteLine((new string[] { "Veni", "Vidi", "Vichi" }).StartsWith("Ve").printList());

            Console.WriteLine("ends with \'ni\' in [Veni,Vidi,Vichi]");
            Console.WriteLine((new string[] { "Veni", "Vidi", "Vichi" }).EndsWithRE("ni").printList());

            Console.WriteLine("ends with \'chi\' in [Veni,Vidi,Vichi]");
            Console.WriteLine((new string[] { "Veni", "Vidi", "Vichi" }).EndsWith("chi").printList());

            Console.Read();
        }
    }
}
