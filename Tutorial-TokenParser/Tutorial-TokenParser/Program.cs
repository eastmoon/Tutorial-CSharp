using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
namespace Tutorial_TokenParser
{
    class Program
    {
        static void Main(string[] args)
        {
            string content = "";
            string output = "";
            bool result = true;
            // 1. String Process
            // 1.1 Comparison
            // ref : https://msdn.microsoft.com/zh-tw/library/cc165449.aspx
            Console.WriteLine("\n------ String process : Comparison ------\n");

            string root1 = @"C:\User";
            string root2 = @"C:\user";
            // Use the overload of the Equals method that specifies a StringComparison.
            // Ordinal is the fastest way to compare two strings.
            result = root1.Equals(root2, StringComparison.Ordinal);
            Console.WriteLine("Ordinal comparison: {0} and {1} are {2}", root1, root2,
                                result ? "equal." : "not equal.");

            // To ignore case means "user" equals "User". This is the same as using
            // String.ToUpperInvariant on each string and then performing an ordinal comparison.
            result = root1.Equals(root2, StringComparison.OrdinalIgnoreCase);
            Console.WriteLine("Ordinal ignore case: {0} and {1} are {2}", root1, root2,
                                 result ? "equal." : "not equal.");

            // A static method is also available.
            bool areEqual = String.Equals(root1, root2, StringComparison.Ordinal);
            Console.WriteLine("Static method : {0} and {1} are {2}", root1, root2,
                                 result ? "equal." : "not equal.");

            // For culture-sensitive comparisons, use the String.Compare overload that takes a StringComparison value.
            // 使用文化特性比較字串，是依據各類語言特性來改變比較規則，若針對特定語言掃瞄有其優勢。

            // 1.2 Search
            // ref : https://msdn.microsoft.com/zh-tw/library/ms228630.aspx
            Console.WriteLine("\n------ String process : Search ------\n");

            content = "Extension methods have all the capabilities of regular static methods.";
            Console.WriteLine("Original text: \n'{0}'", content);

            // This search returns the substring between two strings, so 
            // the first index is moved to the character just after the first string.
            string targetStr = "methods";
            int first = content.IndexOf(targetStr) + targetStr.Length;
            int last = content.LastIndexOf(targetStr);
            string betweenStr = content.Substring(first, last - first);
            System.Console.WriteLine("Substring between \"{0}\" and \"{0}\": \n'{1}'", targetStr, betweenStr);


            // 1.3 Split
            Console.WriteLine("\n------ String process : Split ------\n");
            
            // declare variable
            char[] delimiterChars = { ' ', ',', '.', ':', '\t', '\n' };
            content = "one\ttwo three:four,five six\nseven";
            Console.WriteLine("Original text: '{0}'", content);

            // Split content
            string[] words = content.Split(delimiterChars);
            Console.WriteLine("{0} words in text:", words.Length);

            // Output word
            foreach (string w in words)
            {
                Console.WriteLine(w);
            }

            // 2. Regular Expression
            // ref : http://zh.wikipedia.org/zh-tw/%E6%AD%A3%E5%88%99%E8%A1%A8%E8%BE%BE%E5%BC%8F
            // regular expression online
            // ref : https://regex101.com/
            // regex class
            // ref : https://msdn.microsoft.com/zh-tw/library/system.text.regularexpressions.regex%28v=vs.110%29.aspx

            // 2.1 Match
            Console.WriteLine("\n------ Regular process : Match ------\n");

            string pattern = "";
            // HTML tag pattern
            pattern = @"<[^<]*>";

            // HTML Parse
            content = @"<tag>xxxx</tag><a href='xx'></a><xxx>";
            result = Regex.IsMatch(content, pattern);
            Console.WriteLine("Content : {0}\nPattern : {1}\nMatch : {2}", content, pattern, result);

            // While loop
            Console.WriteLine("\n== While loop ==\n");
            Match match = Regex.Match(content, pattern);
            while( match.Success )
            {
                Console.WriteLine("Match at {0}-{1}, {2}", match.Index, match.Length, match.Value);
                match = match.NextMatch();
            }

            // foreach loop
            Console.WriteLine("\n== Foreach loop ==\n");
            foreach ( Match tag in Regex.Matches(content, pattern))
            {
                Console.WriteLine("Match at {0}-{1}, {2}", tag.Index, tag.Length, tag.Value);
            }

            // 2.2 Replace
            Console.WriteLine("\n------ Regular process : Replace ------\n");
            
            // HTML tag pattern
            pattern = @"<[^<]*>";
        
            // HTML Parse
            content = @"<tag>xxxx</tag><a href='xx'></a><xxx>";
            
            // Replace field string
            string replaceStr = "[y]";
            output = Regex.Replace(content, pattern, replaceStr);

            Console.WriteLine("\n== Replace field string ==\n");
            Console.WriteLine("Content : {0}\nPattern : {1}\nOutput : {2}", content, pattern, output);

            // Replace dynamic string
            // Assign the replace method to the MatchEvaluator delegate.
            MatchEvaluator replaceEvaluator = new MatchEvaluator((new Program()).RegexReplace);
            output = Regex.Replace(content, pattern, replaceEvaluator);

            Console.WriteLine("\n== Replace dynamic string ==\n");
            Console.WriteLine("Content : {0}\nPattern : {1}\nOutput : {2}", content, pattern, output);

            // 2.3 Split
            Console.WriteLine("\n------ Regular process : Replace ------\n");

            // Normal split, pattern will not include in substrings.
            Console.WriteLine("\n== Normal Split ==\n");
            // HTML tag pattern
            pattern = @"\d+";

            // HTML Parse
            content = @"123ABCDE456FGHIJKL789MNOPQ012";

            //Split content
            Console.WriteLine("Content : {0}\nPattern : {1}\nOutput :", content, pattern);

            string[] substrings = Regex.Split(content, pattern);
            foreach (string matchStr in substrings)
            {
                Console.WriteLine("'{0}'", matchStr);
            }

            // include pattern split.
            Console.WriteLine("\n== Include pattern Split ==\n");
            // HTML tag pattern
            pattern = @"(<[^<]*>)";

            // HTML Parse
            content = @"<tag>xxxx</tag><a href='xx'></a><xxx>";

            //Split content
            Console.WriteLine("Content : {0}\nPattern : {1}\nOutput :", content, pattern);

            substrings = Regex.Split(content, pattern);
            foreach (string matchStr in substrings)
            {
                Console.WriteLine("'{0}'", matchStr);
            }


        }

        public string RegexReplace( Match match )
        {
            return "[" + match.Value.Replace("<", "").Replace(">" , "") + "]";
        }
    }
}
