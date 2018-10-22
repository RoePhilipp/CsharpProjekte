using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreshWall
{
    public static class KeywordAnalyzer
    {
        public static List<string> Analyze(string givenText)
        {
            givenText = givenText.Replace(" ", "");
            List<char> buffer = new List<char>();
            List<string> keywords = new List<string>();
            for (int i = 0; i < givenText.Length; i++)
            {
                if(givenText[i] == ';')
                {
                    givenText.Remove(0, i - 1);
                    string keyword = "";
                    foreach(var letter in buffer)
                    {
                        keyword += letter;
                    }
                    keywords.Add(keyword);
                    buffer.Clear();
                }
                else
                {
                    buffer.Add(givenText[i]);
                }
            }

            return keywords;
        }
    }
}
