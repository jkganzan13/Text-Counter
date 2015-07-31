using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace TextCounter
{
    class CountText
    {
        public int count = 0;

        public string[] getSentences(string text)
        {
            //A Sentence starts with a number or a capital letter and ends with ".", "?", "!"
            string[] sentences = Regex.Split(text, @"(?<=[\.\?\!])\s+(?=[A-Z0-9])");
            return sentences;
        }

        public int getWordCount(string text)
        {
            string[] words = splitText(text);
            return words.Length;
        }

        public string[] splitText(string text)
        {
            char[] delimiters = { ' ', ',', ':', '\t', '\r', '\n', '“', '”', '"', '?', '!', '=' };
            string[] words = text.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);

            return words;
        }

        public string getMostWords(string[] sentences)
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

        public List<string> getFreqUsed(string text)
        {
            Dictionary<string, int> wordDict = new Dictionary<string, int>();
            string[] words = splitText(text.Replace("'", "")); //remove apostrophes

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
                    catch (ArgumentOutOfRangeException)
                    {
                        result.Add("'" + word.Key.ToUpper() + "'");
                    }
                }
            }

            return result;
        }

        public List<int> getLetterCount(string[] words)
        {
            List<int> letterCount = new List<int>();
            foreach (string word in words)
            {
                //count characters of string without decimals and apostrophe
                string w = word;
                if (word.Contains('.') || word.Contains("'"))
                {
                    w = word.Replace(".", "").Replace("'", "");
                }
                if (!letterCount.Contains(w.Length))
                {
                    letterCount.Add(w.Length);
                }
            }
            return letterCount;
        }

        public List<string> getLongest(string text)
        {
            List<string> longest = new List<string>();            
            string[] words = splitText(text);
            
            List<int> letterCount = getLetterCount(words);            
            letterCount.Sort();
            letterCount.Reverse();

            int firstLength = letterCount[0];

            //gets word where word.Length == longest length
            foreach (string word in words)
            {
                string w = word.ToString();
                string origW = w;
                int wLength = word.Length;
                //if word contains decimal or apostrophe, remove it then count characterss
                if (word.Contains(".")||word.Contains("'"))
                {
                    w = word.Replace(".", "").Replace("'","");
                    wLength = w.Length;
                }
                //adds original word (may contain full stops, apostrophes, etc.)
                if (w.Length == firstLength && !longest.Contains(origW.ToLower()))
                    longest.Add(origW.ToLower());
            }

            List<string> result = new List<string>();
            foreach (string word in longest)
                result.Add("'" + word.Remove(1).ToUpper() + word.Substring(1) + "'");

            return result;
        }
    }
}
