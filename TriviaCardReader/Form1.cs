using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using IronOcr;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TriviaCardReader
{
    public partial class Form1 : Form
    {
        string[] files;
        // add all relevant image formats for IronOCR
        string[] imageTypes = new string[] { "JPG", "JPEG", "BMP", "GIF", "PNG", "TIFF" };
        List<string> cardData = new List<string>();

        List<string> QandAList = new List<string> { };
        List<string> QuestionList = new List<string> { };
        List<string> AnswerList = new List<string> { };
        string[] questions = new string[] { };
        string[] answers = new string[] { };

        public Form1()
        {
            InitializeComponent();
        }

        private void BtnBrowseFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog TriviaFolder = new FolderBrowserDialog();
            if (TriviaFolder.ShowDialog() == DialogResult.OK)
            {
                files = Directory.GetFiles(TriviaFolder.SelectedPath);
            }

            if (files.Length > 0)
            {
                files = FilterForImageFilesOnly(files);
                if (files.Length == 0)
                {
                    MessageBox.Show("Folder contains no image files.", "Warning:");
                }
                else
                {
                    var Ocr = new AutoOcr();

                    string imageText = string.Empty;
                    foreach (string file in files)
                    {
                        var Result = Ocr.Read(file);

                        imageText = Result.Text;
                        cardData.Add(imageText);
                    }
                    RefreshOutput();
                }

            }
            else
            {
                MessageBox.Show("Folder contains no files.", "Warning:");
            }
        }

        private void RefreshOutput()
        {
            string output = string.Empty;
            foreach (string cardData in cardData)
            {
                output += cardData + "\n";
            }
            rtbOutput.Text = output;
        }

        // filter out all non-image file formats in selected folder
        private string[] FilterForImageFilesOnly(string[] files)
        {
            List<string> imageFiles = new List<string>();
            foreach (string file in files)
            {
                char[] fileExtension = file.ToCharArray();
                string ext = string.Empty;

                for (int i = fileExtension.Length - 1; i > 0; i--)
                {
                    if (fileExtension[i] != '.')
                    {
                        ext = fileExtension[i].ToString() + ext;
                    }
                    else
                    {
                        break;
                    }
                }
                if (imageTypes.Contains(ext.ToUpper()))
                {
                    imageFiles.Add(file);
                }
            }
            files = imageFiles.ToArray();
            return files;
        }

        private void btnExportXml_Click(object sender, EventArgs e)
        {
            //pull in text rows from text box
            string[] triviaRawData = rtbOutput.Lines;
            //remove empty Rows
            List<string> rtbRows = new List<string> { };
            for (int i = 0; i < triviaRawData.Length; i++)
            {
                if (triviaRawData[i].Trim() != "")
                {
                    rtbRows.Add(triviaRawData[i].Trim());
                }
            }
            triviaRawData = rtbRows.ToArray();
            rtbOutput.Clear();
            for (int i = 0; i < triviaRawData.Length; i++)
            {
                rtbOutput.Text += triviaRawData[i] + "\r\n";
            }

            if (triviaRawData.Length % 12 != 0)
            {
                MessageBox.Show("Looks like there's a problem, the number of lines in the text box (currently it's " + triviaRawData.Length + ") must be a multiple of twelve.");
            }
            else
            {
                int counter = 1;
                string[] LineType = new string[] { "GeoQ", "EntQ", "HisQ", "ArtQ", "SciQ", "SpoQ", "GeoA", "EntA", "HisA", "ArtA", "SciA", "SpoA" };
                for (int i = 0; i < (triviaRawData.Length); i++)
                {
                    if (counter <= 6)
                    {
                        QuestionList.Add(triviaRawData[i] + LineType[counter - 1]);
                    }
                    else if (counter > 6)
                    {
                        AnswerList.Add(triviaRawData[i] + LineType[counter - 1]);
                    }
                    counter++;
                    if (counter > 12)
                    {
                        counter = 1;
                    }
                }

                questions = QuestionList.ToArray();
                answers = AnswerList.ToArray();

                for (int i = 0; i < questions.Length; i++)
                {
                    QandAList.Add(questions[i]);
                    QandAList.Add(answers[i]);
                }
            }

            string OutPutText = string.Empty;
            foreach (string question in QandAList)
            {
                OutPutText += question + "\r\n";
            }

            var saveFile = new SaveFileDialog();

            saveFile.Filter = "sav files (*.sav)|*.sav|All files (*.*)|*.*";
            saveFile.FilterIndex = 2;

            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(saveFile.FileName, OutPutText);
                MessageBox.Show("Your list has been save to an external file.\n\nFile Location:\t" + saveFile.FileName);
            }
        }
    }
}
