using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations.Infrastructure;
using System.IO;
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
            fileNameBox.Text = _fileSelection.BrowseFile();
            fileNameBox.ReadOnly = true;
        }

        private void BtnFileDbUpload(object sender, EventArgs e)
        {
            _fileDbService.FileDbUpload(fileNameBox.Text);
            _fileDbService.PrintMessage("Upload");

            DbGridDataLoading();
        }

        private void BtnDbDownload(object sender, EventArgs e)
        {
            const string LOCALEXTTXT = ".txt";
            if (fileGridView.Rows.Count == 0)
            {
                MessageBox.Show(@"Please upload a file to dB!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int checkedItemsNb = GetCheckedItemsNo();

            //if (checkedItemsNb == 1)
            //{

            //    int checkedItemIndex = fileGridView.SelectedCells[0].RowIndex;
            //    DataGridViewRow selectedRow = fileGridView.Rows[checkedItemIndex];

            //    var checkedItem = Convert.ToString(selectedRow.Cells["FileName"].Value);
            //    var checkedExt = Convert.ToString(selectedRow.Cells["DownloadFormat"].Value);

            //    string LOCALPATHROOTH = $@"D:\\App\\TextFileDemoApp-master\\TextFileDemoApp\\bin\\Debug\\{checkedItem}{LOCALEXTTXT}";
            //    var checkedItemContent = _fileSelection.ReadFile(checkedItem + LOCALEXTTXT, LOCALPATHROOTH);
            //    SerializedFile file = _fileSerialization.CreateFile(checkedItem, checkedExt, checkedItemContent);

            //    switch (checkedExt)
            //    {
            //        case "xml":
            //            _fileSerialization.XmlSerializeToFile(SerializedFileDto.MapTo(file));
            //            _fileDbService.PrintMessage("Xml serialized file downloaded");
            //            break;
            //        case "json":
            //            _fileSerialization.JsonSerializeToFile(SerializedFileDto.MapTo(file));
            //            _fileDbService.PrintMessage("Json serialized file downloaded");
            //            break;
            //        case "bin":
            //            _fileSerialization.BinarySerializeToFile(SerializedFileDto.MapTo(file));
            //            _fileDbService.PrintMessage("Bin serialized file downloaded");
            //            break;
            //        default:
            //            MessageBox.Show(@"Please select a format to download");
            //            break;
            //    }
            //}

           if (checkedItemsNb >= 1)
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
                            _fileDbService.PrintMessage("Xml serialized file downloaded");
                            break;
                        case ".json":
                            SerializedFile jsonSerializedFile = _fileSerialization.JsonSerializeToFile(SerializedFileDto.MapTo(file));
                            serializedItemsList.Add(jsonSerializedFile);
                            _fileDbService.PrintMessage("Json serialized file downloaded");
                            break;
                        case ".bin":
                            SerializedFile binSerializedFile = _fileSerialization.JsonSerializeToFile(SerializedFileDto.MapTo(file));
                            serializedItemsList.Add(binSerializedFile);
                            _fileDbService.PrintMessage("Bin serialized file downloaded");
                            break;
                        default:
                            MessageBox.Show(@"Please select a format to download");
                            break;
                    }
                }

                _fileDbService.ZipFileDbDownload(serializedItemsList);
            }

            else
            {
                MessageBox.Show(@"Please select at list a file to download");
            }
        }

        private void BtnDelete(object sender, EventArgs e)
        {
            var checkedItemsList = GetCheckedItemsList();
            _fileDbService.FileDelete(checkedItemsList);
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
                const string LOCALEXTTXT = ".txt";
                bool isChecked = (bool) row.Cells[1].EditedFormattedValue;
                string checkedItem = (string) row.Cells[0].EditedFormattedValue;
                string checkedExt = (string) row.Cells[2].EditedFormattedValue;

                string LOCALPATHROOTH =
                    $@"D:\\App\\TextFileDemoApp-master\\TextFileDemoApp\\bin\\Debug\\{checkedItem}{LOCALEXTTXT}";

                if ((isChecked) && (File.Exists(LOCALPATHROOTH)))
                {
                    var checkedItemContent = _fileSelection.ReadFile(checkedItem + LOCALEXTTXT, LOCALPATHROOTH);

                    SerializedFile file =
                        _fileSerialization.CreateFile(checkedItem, "." + checkedExt, checkedItemContent);
                    checkedItemsList.Add(file);
                }
                else if (isChecked == false)
                    MessageBox.Show(@"Please select a file to download");
                else
                {
                    MessageBox.Show(@"Local file not found");
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
