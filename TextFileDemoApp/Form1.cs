using System;
using System.Collections.Generic;
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
        private readonly FileLocalService _fileLocalService;

        public TextFileForm()
        {
            _fileSelection = new FileSelection();
            _fileSerialization = new FileSerialization();
            _fileLocalService = new FileLocalService();

            List<SerializedFileDto> fileDtoList = new List<SerializedFileDto>();

            InitializeComponent();
            DbGridDataLoading();
            BrowseFileInitialize();
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

        List<SerializedFileDto> fileDtoList = new List<SerializedFileDto>();
        private void BtnFileGridUpload(object sender, EventArgs e)
        {
            DownloadFormat.ValueType = typeof(FileExtEnum);
            DownloadFormat.DataSource = Enum.GetValues(typeof(FileExtEnum));            

            SerializedFileDto file = _fileLocalService.FileGridUpload(fileNameBox.Text);
            fileDtoList.Add(file);
            fileGridView.DataSource = fileDtoList;
        }

        public void DbGridDataLoading()
        {


        }

        private void BtnSerialize(object sender, EventArgs e)
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

                const string LOCALPATHROOTH = "D:\\App\\TextFileDemoApp\\TextFileDemoApp\\bin\\Debug\\";
                string localPath = $@"{LOCALPATHROOTH}{checkedItem}{'.' + checkedExt}";


                var checkedItemContent = File.ReadAllText(localPath);
                SerializedFileDto file = _fileSerialization.CreateFile(checkedItem, checkedExt, checkedItemContent);




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

                List<SerializedFileDto> serializedItemsList = new List<SerializedFileDto>();
                foreach (var file in checkedItemsList)
                {
                    string checkedExt = file.Extension;
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

                bool isArchived = _fileLocalService.ZipFileArchive(serializedItemsList);
                if (isArchived)
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

            bool isDeleted = _fileLocalService.FileDelete(checkedItemsList);
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

        public List<SerializedFileDto> GetCheckedItemsList()
        {
            List<SerializedFileDto> checkedItemsList = new List<SerializedFileDto>();

            foreach (DataGridViewRow row in fileGridView.Rows)
            {
                bool isChecked = (bool)row.Cells[1].EditedFormattedValue;
                string checkedItem = (string)row.Cells[0].EditedFormattedValue;
                string checkedExt = (string)row.Cells[2].EditedFormattedValue;

                if (isChecked)
                {
                    const string LOCALPATHROOTH = "D:\\App\\TextFileDemoApp\\TextFileDemoApp\\bin\\Debug\\";
                    string localPath = $@"{LOCALPATHROOTH}{checkedItem}";
                    var checkedItemContent = _fileSelection.ReadFile(checkedItem, localPath);

                    SerializedFileDto file =
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
