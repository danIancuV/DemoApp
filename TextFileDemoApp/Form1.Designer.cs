using System.Windows.Forms;

namespace TextFileDemoApp
{
    partial class TextFileForm
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
            this.components = new System.ComponentModel.Container();
            this.button1 = new System.Windows.Forms.Button();
            this.fileNameBox = new System.Windows.Forms.TextBox();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button11 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.serializedFileBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.fileGridView = new System.Windows.Forms.DataGridView();
            this.FileCheck = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.DownloadFormat = new System.Windows.Forms.DataGridViewComboBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.serializedFileBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(174, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Browse File";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.ButtonBrowseFile_Click);
            // 
            // fileNameBox
            // 
            this.fileNameBox.Location = new System.Drawing.Point(53, 12);
            this.fileNameBox.Name = "fileNameBox";
            this.fileNameBox.Size = new System.Drawing.Size(115, 20);
            this.fileNameBox.TabIndex = 3;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(149, 63);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(100, 23);
            this.button6.TabIndex = 7;
            this.button6.Text = "File Grid Upload";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.BtnFileGridUpload);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(149, 118);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(100, 23);
            this.button7.TabIndex = 9;
            this.button7.Text = "Serialize";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.BtnSerialize);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(798, 11);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(24, 21);
            this.button8.TabIndex = 10;
            this.button8.Text = "X";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.BtnExitProgram_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(135, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Please select a file first";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(39, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(210, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Please select a file or multiple files in the list";
            // 
            // button11
            // 
            this.button11.Location = new System.Drawing.Point(149, 166);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(100, 23);
            this.button11.TabIndex = 15;
            this.button11.Text = "Delete";
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Click += new System.EventHandler(this.BtnDelete);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(39, 150);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(210, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "Please select a file or multiple files in the list";
            // 
            // serializedFileBindingSource
            // 
            this.serializedFileBindingSource.DataMember = "SerializedFile";
            // 
            // fileGridView
            // 
            this.fileGridView.AllowUserToAddRows = false;
            this.fileGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.fileGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FileCheck,
            this.DownloadFormat});
            this.fileGridView.Location = new System.Drawing.Point(42, 210);
            this.fileGridView.Name = "fileGridView";
            this.fileGridView.Size = new System.Drawing.Size(710, 187);
            this.fileGridView.TabIndex = 17;
            // 
            // FileCheck
            // 
            this.FileCheck.HeaderText = "FileCheck";
            this.FileCheck.Name = "FileCheck";
            // 
            // DownloadFormat
            // 
            this.DownloadFormat.HeaderText = "DownloadFormat";
            this.DownloadFormat.Name = "DownloadFormat";
            // 
            // TextFileForm
            // 
            this.ClientSize = new System.Drawing.Size(834, 494);
            this.Controls.Add(this.fileGridView);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button11);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.fileNameBox);
            this.Controls.Add(this.button1);
            this.Name = "TextFileForm";
            ((System.ComponentModel.ISupportInitialize)(this.serializedFileBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public Button button1;
        public TextBox fileNameBox;
        protected Button button6;
        protected Button button7;
        protected Button button8;
        protected Label label1;
        protected Label label2;
        protected Button button11;
        protected Label label3;

        private BindingSource serializedFileBindingSource;

        
        private DataGridView fileGridView;
        private DataGridViewCheckBoxColumn FileCheck;
        private DataGridViewComboBoxColumn DownloadFormat;
    }
}

