using System;
using System.Linq;
using System.Numerics;
using System.Text.RegularExpressions;

namespace LongestCommonPrefix
{

    class Programm
    {
        

        static void Main(string[] args)
        {

            string inp = "e e e e DDD ddd DdD: ddd ddd aa aA Aa, bb cc cC e e e";

            List<string> list = Top3(inp);

            foreach (var item in list)
            {
                Console.WriteLine(item);
            }

          
            
        }

        public static List<string> Top3(string s)
        {

            string ss = s.ToLower();

            //char[] separators = { ' ', '.', ',' };

            string pattern = @"\b\w+(?:'\w+)?\b";

            Regex regex = new Regex(pattern);

            var matchcol = regex.Matches(ss);

            string[] s1 = matchcol.Cast<Match>().Select(x => x.Value.ToLower()).ToArray();

            //string[] s1 = ss.Split(separators);

            if (s1.Length <= 2)
            {
                List<string> res1 = s1.ToList();
                return res1;
            }

            List<string> res = s1.GroupBy(x => x).OrderByDescending(g => g.Count()).Select(x => x.Key).Take(3).ToList();

            return res;
        }

    }
}