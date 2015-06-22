using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Intergen
{
    public partial class countTextForm : Form
    {
        string filePath = "";
        string text = "";
        Boolean exceptionFlag;
       
        public countTextForm()
        {
            InitializeComponent();
        }

        private void browse_button_Click(object sender, EventArgs e)
        {
            DialogResult location = locationDialog.ShowDialog();
            filePath = "";
            if (location == DialogResult.OK)
            {
                filePath = locationDialog.FileName;
                locationBox.Text = filePath;                
            }
        }

        private void execute_button_Click(object sender, EventArgs e)
        {
            resultBox.Clear();
            //read text file from filePath
            try
            {
                exceptionFlag = false;                
                text = File.ReadAllText(locationBox.Text, Encoding.GetEncoding("Windows-1252"));
                if (!Path.GetExtension(locationBox.Text).Equals(".txt", StringComparison.InvariantCultureIgnoreCase))
                    throw new FormatException();
                if (text.Length == 0 || text.Replace(" ", string.Empty).Length == 0 || text.Replace("\n", string.Empty).Length == 0 || text.Replace("\r\n", string.Empty).Length == 0)
                    throw new IOException();
                if (locationBox.Text == null || locationBox.Text == "")
                    throw new FileNotFoundException();
            }
            catch (FileNotFoundException ex)
            {
                resultBox.Text = "ERROR: File Not Found!";
                exceptionFlag = true;
                
            }
            catch (FormatException ex)
            {
                resultBox.Text = "ERROR: File cannot be opened. Make sure it is a Text File.";
                exceptionFlag = true;
            }
            catch (IOException ex)
            {
                resultBox.Text = "ERROR: Text File is Empty.";
                exceptionFlag = true;
            }
            catch (ArgumentException ex)
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
                //store sentences into an aray and count number of sentences
                string[] sentences = CountText.getSentences(text);
                //write to resultBox
                resultBox.AppendText("Number of Sentences: " + sentences.Length + "\n");

                //count words in text
                int wordCount = CountText.getWordCount(text);
                //write to resultBox
                resultBox.AppendText("\r\nNumber of Words: " + wordCount + "\n");

                //find sentence with most words
                string mostWords = CountText.getMostWords(sentences);
                //write to resultBox
                resultBox.AppendText("\r\nSentence with most words: Sentence " + CountText.count + " - " + "\"" + mostWords + "\"\n");
                
                //find most frequently used word(s)
                List<string> freqUsed = CountText.getFreqUsed(text);
                //write to resultBox                
                resultBox.AppendText("\r\nMost Frequently Used Word(s): " + string.Join(", ", freqUsed) + "\n");
                
                //find 3rd longest word(s)
                List<string> thirdLongest = CountText.getThirdLongest(text);
                //write to resultBox
                int wLength = 0;
                string w = "";
                if (thirdLongest.Count() == 1)
                    resultBox.AppendText("\r\n3rd Longest word(s): \'" + thirdLongest[0].Remove(1).ToUpper() + thirdLongest[0].Substring(1) + "\' is " + thirdLongest[0].Substring(1, thirdLongest[0].Length - 2).Length + " characters long.\n");
                else
                {
                    w = thirdLongest[0].Substring(1, thirdLongest[0].Length - 2);
                    wLength = w.Replace(".", "").Length;
                    resultBox.AppendText("\r\n3rd Longest word(s): " + string.Join(", ", thirdLongest) + " are " + wLength + " characters long.\n");
                }
            }
        }             
    }
}
