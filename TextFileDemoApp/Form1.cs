using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations.Infrastructure;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using FileClassLibrary;
using FileClassLibrary.FileServiceModel;

namespace TextFileDemoApp
{
    public partial class TextFileForm : Form
    {
        private readonly FileSelection _fileSelection;
        private readonly FileSerialization _fileSerialization;
        private readonly FileDbService _fileDbService;

        public TextFileForm()
        {
            _fileSelection = new FileSelection();
            _fileSerialization = new FileSerialization();
            _fileDbService = new FileDbService();

            InitializeComponent();
            DbGridDataLoading();
            BrowseFileInitialize();

        }

        public void DbGridDataLoading()
        {
            serializedFileTableAdapter.Fill(filedbDataSet.SerializedFile);

            DownloadFormat.ValueType = typeof(FileExtEnum);
            DownloadFormat.DataSource = Enum.GetValues(typeof(FileExtEnum));
        }

        private void BrowseFileInitialize()
        {
            button6.Enabled = false;
        }

        private void ButtonBrowseFile_Click(object sender, EventArgs e)
        {
            button6.Enabled = true;
            fileNameBox.Text = BrowseFile();
            fileNameBox.ReadOnly = true;

            string BrowseFile()
            {
                OpenFileDialog openFd = new OpenFileDialog();

                if (openFd.ShowDialog() == DialogResult.OK)
                {
                    return Path.GetFileName(openFd.FileName);
                }

                return null;
            }
        }

        private void BtnFileDbUpload(object sender, EventArgs e)
        {

            bool isUploaded = _fileDbService.FileDbUpload(fileNameBox.Text);
            if (isUploaded)
            {
                MessageBox.Show(@"Upload done");
            }
            else
            {
                MessageBox.Show(@"Local file not found");
                return;
            }

            DbGridDataLoading();
        }

        private void BtnDbDownload(object sender, EventArgs e)
        {
            if (fileGridView.Rows.Count == 0)
            {
                MessageBox.Show(@"Please upload a file to dB!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int checkedItemsNb = GetCheckedItemsNo();

            if (checkedItemsNb == 1)
            {

                int checkedItemIndex = fileGridView.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = fileGridView.Rows[checkedItemIndex];

                var checkedItem = Convert.ToString(selectedRow.Cells["FileName"].Value);
                var checkedExt = "." + Convert.ToString(selectedRow.Cells["DownloadFormat"].Value);

                var db = new FiledbEntities();
                var checkedItemContent = db.SerializedFiles.FirstOrDefault(x =>
                    x.Name == checkedItem)?.FileContent;

                SerializedFile file = _fileSerialization.CreateFile(checkedItem, checkedExt, checkedItemContent);

                switch (checkedExt)
                {
                    case ".xml":
                        _fileSerialization.XmlSerializeToFile(SerializedFileDto.MapTo(file));
                        MessageBox.Show(@"Xml serialized file downloaded");
                        break;
                    case ".json":
                        _fileSerialization.JsonSerializeToFile(SerializedFileDto.MapTo(file));
                        MessageBox.Show(@"Json serialized file downloaded");
                        break;
                    case ".bin":
                        _fileSerialization.BinarySerializeToFile(SerializedFileDto.MapTo(file));
                        MessageBox.Show(@"Bin serialized file downloaded");
                        break;
                    default:
                        MessageBox.Show(@"Please select a format to download");
                        break;
                }
            }

            else if (checkedItemsNb > 1)
            {
                var checkedItemsList = GetCheckedItemsList();

                List<SerializedFile> serializedItemsList = new List<SerializedFile>();
                foreach (var file in checkedItemsList)
                {
                    string checkedExt = file.Extension;
                    switch (checkedExt)
                    {
                        case ".xml":
                            SerializedFile xmlSerializedFile = _fileSerialization.XmlSerializeToFile(SerializedFileDto.MapTo(file));
                            serializedItemsList.Add(xmlSerializedFile);
                            
                            break;
                        case ".json":
                            SerializedFile jsonSerializedFile = _fileSerialization.JsonSerializeToFile(SerializedFileDto.MapTo(file));
                            serializedItemsList.Add(jsonSerializedFile);
                            
                            break;
                        case ".bin":
                            SerializedFile binSerializedFile = _fileSerialization.JsonSerializeToFile(SerializedFileDto.MapTo(file));
                            serializedItemsList.Add(binSerializedFile);
                            
                            break;
                        default:
                            MessageBox.Show(@"Please select a format to download");
                            return;
                    }
                }

                bool isDownloaded = _fileDbService.ZipFileDbDownload(serializedItemsList);
                if (isDownloaded)
                {
                    MessageBox.Show(@"Zip download done");
                    return;
                }
                else
                {
                    MessageBox.Show(@"Please Select a file to download");
                    return;
                }
            }
            else
            {
                MessageBox.Show(@"Please select a file to download");
            }
        }

        private void BtnDelete(object sender, EventArgs e)
        {
            var checkedItemsList = GetCheckedItemsList();

            bool isDeleted = _fileDbService.FileDelete(checkedItemsList);
            if (isDeleted)
            {
                MessageBox.Show(@"File Deleted");
            }
            else
            {
                MessageBox.Show(@"Please select a file");
            }

            DbGridDataLoading();
        }
            
        public int GetCheckedItemsNo()
        {
            int checkedItemsNo = 0;

            foreach (DataGridViewRow row in fileGridView.Rows)
            {
                bool isChecked = (bool)row.Cells[1].EditedFormattedValue;
                if (isChecked)
                {
                    checkedItemsNo++;
                }
            }

            return checkedItemsNo;
        }

        public List<SerializedFile> GetCheckedItemsList()
        {
            List<SerializedFile> checkedItemsList = new List<SerializedFile>();

            foreach (DataGridViewRow row in fileGridView.Rows)
            {
                bool isChecked = (bool)row.Cells[1].EditedFormattedValue;
                string checkedItem = (string)row.Cells[0].EditedFormattedValue;
                string checkedExt = (string)row.Cells[2].EditedFormattedValue;

                if (isChecked)
                {
                    var db = new FiledbEntities();
                    var checkedItemContent = (db.SerializedFiles.FirstOrDefault(x =>
                        x.Name == checkedItem))?.FileContent;

                    SerializedFile file =
                        _fileSerialization.CreateFile(checkedItem, "." + checkedExt, checkedItemContent);
                    checkedItemsList.Add(file);
                }

            }
            return checkedItemsList;
        }

        private void BtnExitProgram_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}
