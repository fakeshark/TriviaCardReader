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
    }
}
