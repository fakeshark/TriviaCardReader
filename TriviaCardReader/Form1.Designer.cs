namespace TriviaCardReader
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnBrowseFolder = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnExportXml = new System.Windows.Forms.Button();
            this.gbxBrowse = new System.Windows.Forms.GroupBox();
            this.lblInfo = new System.Windows.Forms.Label();
            this.rtbOutput = new System.Windows.Forms.RichTextBox();
            this.gbxBrowse.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnBrowseFolder
            // 
            this.btnBrowseFolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBrowseFolder.Location = new System.Drawing.Point(474, 17);
            this.btnBrowseFolder.Name = "btnBrowseFolder";
            this.btnBrowseFolder.Size = new System.Drawing.Size(47, 25);
            this.btnBrowseFolder.TabIndex = 0;
            this.btnBrowseFolder.Text = "...";
            this.btnBrowseFolder.UseVisualStyleBackColor = true;
            this.btnBrowseFolder.Click += new System.EventHandler(this.BtnBrowseFolder_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(10, 19);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(458, 20);
            this.textBox1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 122);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "OCR Output:";
            // 
            // btnExportXml
            // 
            this.btnExportXml.Enabled = false;
            this.btnExportXml.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportXml.Location = new System.Drawing.Point(12, 468);
            this.btnExportXml.Name = "btnExportXml";
            this.btnExportXml.Size = new System.Drawing.Size(530, 26);
            this.btnExportXml.TabIndex = 5;
            this.btnExportXml.Text = "Export text to file";
            this.btnExportXml.UseVisualStyleBackColor = true;
            // 
            // gbxBrowse
            // 
            this.gbxBrowse.Controls.Add(this.lblInfo);
            this.gbxBrowse.Controls.Add(this.btnBrowseFolder);
            this.gbxBrowse.Controls.Add(this.textBox1);
            this.gbxBrowse.Location = new System.Drawing.Point(12, 13);
            this.gbxBrowse.Name = "gbxBrowse";
            this.gbxBrowse.Size = new System.Drawing.Size(530, 100);
            this.gbxBrowse.TabIndex = 7;
            this.gbxBrowse.TabStop = false;
            this.gbxBrowse.Text = "Browse to image folder: ";
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Location = new System.Drawing.Point(8, 46);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(28, 13);
            this.lblInfo.TabIndex = 3;
            this.lblInfo.Text = "Info:";
            // 
            // rtbOutput
            // 
            this.rtbOutput.Location = new System.Drawing.Point(12, 138);
            this.rtbOutput.Name = "rtbOutput";
            this.rtbOutput.Size = new System.Drawing.Size(530, 324);
            this.rtbOutput.TabIndex = 8;
            this.rtbOutput.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(556, 509);
            this.Controls.Add(this.rtbOutput);
            this.Controls.Add(this.gbxBrowse);
            this.Controls.Add(this.btnExportXml);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Trivial Pursuit Card Transcriber";
            this.gbxBrowse.ResumeLayout(false);
            this.gbxBrowse.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBrowseFolder;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnExportXml;
        private System.Windows.Forms.GroupBox gbxBrowse;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.RichTextBox rtbOutput;
    }
}

