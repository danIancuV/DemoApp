using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using FileClassLibrary.FileServiceModel;

namespace TextFileDemoApp
{
    public partial class TextFileForm : Form
    {
        public readonly FileSerialization _fileSerialization;
        public readonly FileLocalService _fileLocalService;
        

        public TextFileForm()
        {
            _fileSerialization = new FileSerialization();
            _fileLocalService = new FileLocalService();
            
            InitializeComponent();
      
            BrowseFileInitialize();
        }

        private void BrowseFileInitialize()
        {
            button6.Enabled = false;
        }

        private void BtnBrowseFile(object sender, EventArgs e)
        {
            button6.Enabled = true;
            fileNameBox.Text = BrowseFile();
            fileNameBox.ReadOnly = true;

            string BrowseFile()
            {
                var openFd = new OpenFileDialog();

                return openFd.ShowDialog() == DialogResult.OK ? Path.GetFileName(openFd.FileName) : null;
            }
        }
        
        private void BtnFileGridUpload(object sender, EventArgs e)
        {                       
            fileGridView.DataSource = typeof(List<SerializedFileDto>);
            fileGridView.DataSource = _fileLocalService.FileGridUpload(fileNameBox.Text);
            DownloadFormat.ValueType = typeof(FileExtEnum);
            DownloadFormat.DataSource = Enum.GetValues(typeof(FileExtEnum));
        }

        private void BtnSerialize(object sender, EventArgs e)
        {
            if (fileGridView.Rows.Count == 0)
            {
                MessageBox.Show(@"Please upload a file to Grid!", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var checkedItemsNb = GetCheckedItemsNo();

            if (checkedItemsNb == 1)
            {

                var checkedItemIndex = fileGridView.SelectedCells[0].RowIndex;
                var selectedRow = fileGridView.Rows[checkedItemIndex];

                var checkedItem = Convert.ToString(selectedRow.Cells["Name"].Value);
                var checkedExt = "." + Convert.ToString(selectedRow.Cells["DownloadFormat"].Value);

                const string localext = ".txt";
                const string localpathrooth = "D:\\App\\TextFileDemoApp\\TextFileDemoApp\\bin\\Debug\\";
                var localPath = $@"{localpathrooth}{checkedItem}{localext}";

                var checkedItemContent = File.ReadAllText(localPath);
                var file = _fileSerialization.CreateFile(checkedItem, checkedExt, checkedItemContent);

                switch (checkedExt)
                {
                    case ".xml":
                        _fileSerialization.XmlSerializeToFile(file);
                        MessageBox.Show(@"Xml serialized file downloaded");
                        break;
                    case ".json":
                        _fileSerialization.JsonSerializeToFile(file);
                        MessageBox.Show(@"Json serialized file downloaded");
                        break;
                    case ".bin":
                        _fileSerialization.BinarySerializeToFile(file);
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

                var serializedItemsList = new List<SerializedFileDto>();
                foreach (var file in checkedItemsList)
                {
                    var checkedExt = file.Extension;
                    switch (checkedExt)
                    {
                        case ".xml":
                            SerializedFileDto xmlSerializedFile = _fileSerialization.XmlSerializeToFile(file);
                            serializedItemsList.Add(xmlSerializedFile);
                            break;
                        case ".json":
                            SerializedFileDto jsonSerializedFile = _fileSerialization.JsonSerializeToFile(file);
                            serializedItemsList.Add(jsonSerializedFile);
                            break;
                        case ".bin":
                            SerializedFileDto binSerializedFile = _fileSerialization.JsonSerializeToFile(file);
                            serializedItemsList.Add(binSerializedFile);
                            break;
                        default:
                            MessageBox.Show(@"Please select a format to download");
                            return;
                    }
                }

                var isArchived = _fileLocalService.ZipFileArchive(serializedItemsList);
                MessageBox.Show(isArchived ? @"Zip download done" : @"Please Select a file to download");
            }
            else
            {
                MessageBox.Show(@"Please select a file to download");
            }
        }

        private void BtnDelete(object sender, EventArgs e)
        {
            var checkedItemsList = GetCheckedItemsList();

            var dtoAfterDeleteList = _fileLocalService.FileDelete(checkedItemsList);
            if (dtoAfterDeleteList != null)
            {
                fileGridView.DataSource = typeof(List<SerializedFileDto>);
                fileGridView.DataSource = dtoAfterDeleteList;
                DownloadFormat.ValueType = typeof(FileExtEnum);
                DownloadFormat.DataSource = Enum.GetValues(typeof(FileExtEnum));
                MessageBox.Show(@"Deletion completed");
            }
            else
            {
                MessageBox.Show(@"Please select an item to delete");
            }

        }

        public int GetCheckedItemsNo()
        {
            var checkedItemsNo = 0;

            for (var index = 0; index < fileGridView.Rows.Count; index++)
            {
                var row = fileGridView.Rows[index];
                var isChecked = (bool) row.Cells[0].EditedFormattedValue;
                if (isChecked)
                {
                    checkedItemsNo++;
                }
            }

            return checkedItemsNo;
        }

        public List<SerializedFileDto> GetCheckedItemsList()
        {
            var checkedItemsList = new List<SerializedFileDto>();

            foreach (DataGridViewRow row in fileGridView.Rows)
            {
                var isChecked = (bool)row.Cells[0].EditedFormattedValue;
                var checkedItem = (string)row.Cells[2].EditedFormattedValue;
                var checkedExt = (string)row.Cells[1].EditedFormattedValue;

                if (!isChecked) continue;
                const string localpathrooth = "D:\\App\\TextFileDemoApp\\TextFileDemoApp\\bin\\Debug\\";
                var localPath = $@"{localpathrooth}{checkedItem}";
                var checkedItemContent = _fileSerialization.ReadFile(checkedItem, localPath);

                var file =
                    _fileSerialization.CreateFile(checkedItem, "." + checkedExt, checkedItemContent);
                checkedItemsList.Add(file);

            }
            return checkedItemsList;
        }

        private void BtnExitProgram_Click(object sender, EventArgs e)
        {
            Close();
        }

    }

}
