using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TextCounter
{
    public partial class countTextForm : Form
    {
        string textFile = "";
        Boolean exceptionFlag;

        public countTextForm()
        {
            InitializeComponent();
        }

        private void browse_button_Click(object sender, EventArgs e)
        {
            DialogResult location = locationDialog.ShowDialog();
            if (location == DialogResult.OK)
            {
                string filePath = locationDialog.FileName;
                locationBox.Text = filePath;
            }
        }        

        private void execute_button_Click(object sender, EventArgs e)
        {
            resultBox.Clear();
            
            try
            {
                //read text file from filePath
                readFromPath();
            }
            catch (FileNotFoundException)
            {
                resultBox.Text = "ERROR: File Not Found!";
                exceptionFlag = true;

            }
            catch (FormatException)
            {
                resultBox.Text = "ERROR: File cannot be opened. Make sure it is a Text File.";
                exceptionFlag = true;
            }
            catch (IOException)
            {
                resultBox.Text = "ERROR: Text File is Empty.";
                exceptionFlag = true;
            }
            catch (ArgumentException)
            {
                resultBox.Text = "ERROR: Enter File Address of text file.";
                exceptionFlag = true;
            }
            catch (Exception ex)
            {
                resultBox.Text = "ERROR: " + ex.Message;
                exceptionFlag = true;
            }

            if (exceptionFlag == false)
            {
                executeTextCount();
            }
        }

        private void readFromPath()
        {
            exceptionFlag = false;
            textFile = File.ReadAllText(locationBox.Text, Encoding.GetEncoding("Windows-1252"));
            if (!Path.GetExtension(locationBox.Text).Equals(".txt", StringComparison.InvariantCultureIgnoreCase))
                throw new FormatException();
            if (textFile.Length == 0 || textFile.Replace(" ", string.Empty).Length == 0 || textFile.Replace("\n", string.Empty).Length == 0 || textFile.Replace("\r\n", string.Empty).Length == 0)
                throw new IOException();
            if (locationBox.Text == null || locationBox.Text == "")
                throw new FileNotFoundException();
        }

        private void executeTextCount()
        {
            CountText ct = new CountText();
            //store sentences into an aray and count number of sentences
            string[] sentences = ct.getSentences(textFile);
            //write to resultBox
            resultBox.AppendText("Number of Sentences: " + sentences.Length + "\n");

            //count words in text
            int wordCount = ct.getWordCount(textFile);
            resultBox.AppendText("\r\nNumber of Words: " + wordCount + "\n");

            //find sentence with most words
            string mostWords = ct.getMostWords(sentences);
            resultBox.AppendText("\r\nSentence with most words: Sentence " + ct.count + " - " + "\"" + mostWords + "\"\n");

            //find most frequently used word(s)
            List<string> freqUsed = ct.getFreqUsed(textFile);
            resultBox.AppendText("\r\nMost Frequently Used Word(s): " + string.Join(", ", freqUsed) + "\n");

            //find longest word(s)
            List<string> longest = ct.getLongest(textFile);
            //write to resultBox
            int wLength = 0;
            string w = "";
            if (longest.Count() == 1)
                resultBox.AppendText("\r\nLongest word(s): \'" + longest[0].Remove(1).ToUpper() + longest[0].Substring(1) + "\' is " + longest[0].Substring(1, longest[0].Length - 2).Length + " characters long.\n");
            else
            {
                w = longest[0].Substring(1, longest[0].Length - 2);
                wLength = w.Replace(".", "").Length;
                resultBox.AppendText("\r\nLongest word(s): " + string.Join(", ", longest) + " are " + wLength + " characters long.\n");
            }
        }
    }
}
