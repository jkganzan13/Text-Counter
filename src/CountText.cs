using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Intergen
{
    public class CountText
    {
        public static int count = 0;

        public static string[] getSentences(string text)
        {
            string[] sentences = Regex.Split(text, @"(?<=[\.\?\!])\s+(?=[A-Z])");
            return sentences;
        }

        public static int getWordCount(string text)
        {
            string[] words = splitText(text);
            return words.Length;
        }

        public static string[] splitText(string text)
        {
            char[] delimiters = { ' ', ',', ':', '\t', '\r', '\n', '“', '”', '"', '?', '!','=' };
            string[] words = text.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);

            return words;
        }

        public static string getMostWords(string[] sentences)
        {
            string sentence = "";
            int highestCount = 0;
            for (int i = 0; i < sentences.Length; i++)
            {
                int currentCount = getWordCount(sentences[i]);
                if (i == 0)
                {
                    highestCount = currentCount;
                    sentence = sentences[i];
                    count = i + 1;
                }
                if (currentCount > highestCount) //if current sentence has more words
                {
                    highestCount = currentCount;
                    sentence = sentences[i];
                    count = i + 1;
                }
            }
            return sentence;
        }        

        public static List<string> getFreqUsed(string text)
        {
            Dictionary<string, int> wordDict = new Dictionary<string, int>();
            string[] words = splitText(text.Replace("'", "")); //remove apostrophes & period

            foreach (string word in words)
            {
                string w = word;
                if (word.EndsWith("."))
                    w = word.Substring(0, word.Length - 1);
                if (wordDict.ContainsKey(w.ToLower()))
                    wordDict[w.ToLower()] = wordDict[w.ToLower()] + 1;
                else
                    wordDict[w.ToLower()] = 1;
            }

            List<string> result = new List<string>();
            foreach (KeyValuePair<string, int> word in wordDict)
            {
                if (word.Value == wordDict.Values.Max())
                {
                    try
                    {
                        result.Add("'" + word.Key.Remove(1).ToUpper() + word.Key.Substring(1) + "'");
                    }
                    catch (ArgumentOutOfRangeException ex)
                    {
                        result.Add("'" + word.Key.ToUpper() + "'");
                    }
                }
            }

            return result;
        }

        public static List<string> getThirdLongest(string text)
        {
            List<string> thirdLongest = new List<string>();
            List<int> letterCount = new List<int>();
            string[] words = splitText(text.Replace("'", "")); //remove apostrophes and decimals
            
            foreach (string word in words)
            {
                //count characters of string without decimals
                string w = word;
                if (word.Contains('.'))
                {
                    w = word.Replace(".", "");
                }
                if (!letterCount.Contains(w.Length))
                {
                    letterCount.Add(w.Length);
                }
            }
            letterCount.Sort();
            letterCount.Reverse();

            var thirdLength = 0;
            try
            {
                thirdLength = letterCount[2];
            }
            catch (ArgumentOutOfRangeException ex)
            {
                thirdLength = letterCount[letterCount.Count-1];
            }
            
            foreach (var word in words)
            {
                string w = word.ToString();
                string origW = w;
                int wLength = word.Length;
                //if word contains decimal, remove it then count chars
                if (word.Contains("."))
                {
                    w = word.Replace(".", "");
                    wLength = w.Length;
                }
                if (w.Length == thirdLength && !thirdLongest.Contains(origW.ToLower()))
                    thirdLongest.Add(origW.ToLower());
            }

            List<string> result = new List<string>();
            foreach (string word in thirdLongest)
                result.Add("'" + word.Remove(1).ToUpper() + word.Substring(1) + "'");

            return result;
        }
    }
}
