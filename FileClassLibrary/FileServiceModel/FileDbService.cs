using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Windows.Forms;

namespace FileClassLibrary.FileServiceModel
{

    public class FileDbService
    {

        public bool FileDbUpload(string fileName)
        {
            string localPath = $@"D:\\App\\TextFileDemoApp\\TextFileDemoApp\\bin\\Debug\\{fileName}";

            if (File.Exists(localPath))
            {
                var db = new FiledbEntities();

                var fileModel = new SerializedFileDto
                {
                    Name = fileName.Split('.')[0],
                    Extension = fileName.Split('.')[1],
                    FileContent = File.ReadAllText(localPath),
                };

                var file = SerializedFileDto.MapTo(fileModel);

                db.SerializedFiles.Add(file);
                db.SaveChanges();
                return true;
            }
            else
            {
                
                return false;
            }
        }

        public void ZipFileDbDownload(List<SerializedFile> checkedItemsList)
        {

            const string LOCALPATHROOTH = "D:\\App\\TextFileDemoApp\\Serialized dB downloaded\\Files.zip";

            string zipPath =$@"{LOCALPATHROOTH}";

            foreach (var file in checkedItemsList)
            {
                if (file == null)
                {
                    MessageBox.Show(@"File not found in dB!");
                    return;
                }

                else
                {
                    using (FileStream zipToOpen = new FileStream(zipPath, FileMode.OpenOrCreate))
                    {
                        using (ZipArchive archive = new ZipArchive(zipToOpen, ZipArchiveMode.Update))
                        {
                            ZipArchiveEntry readmeEntry =
                                archive.CreateEntry(file.Name + file.Extension);
                            using (StreamWriter writer = new StreamWriter(readmeEntry.Open()))
                            {
                                writer.Write(file.FileContent);
                                writer.Close();
                            }
                        }
                    }

                    PrintMessage("Download and zip complete");
                }
            }
        }

        public void FileDelete(List<SerializedFile> checkedItemsList)
        {
            var db = new FiledbEntities();
            int i = 0;

            if (checkedItemsList.Count != 0)
            {
                do
                {
                    var checkedfileName = checkedItemsList[i].Name;
                    var checkedfileExt = ".txt";
                    var localPath =
                        $@"D:\\App\\TextFileDemoApp\\TextFileDemoApp\\bin\\Debug\\{checkedfileName}{checkedfileExt}";
                    var dbFile = db.SerializedFiles.FirstOrDefault(x =>
                        x.Name == checkedfileName);
                    if ((dbFile != null) && (File.Exists(localPath)))
                    {
                        db.SerializedFiles.Remove(dbFile);
                        db.SaveChanges();
                        checkedItemsList.Remove(checkedItemsList[i]);
                        File.Delete(localPath);
                        MessageBox.Show(@"Local and Db file deleted");

                    }
                    else if (dbFile == null)
                    {
                        File.Delete(localPath);
                        MessageBox.Show(@"Local file deleted / dB file not found");

                    }
                    else
                    {
                        db.SerializedFiles.Remove(dbFile);
                        db.SaveChanges();
                        checkedItemsList.Remove(checkedItemsList[i]);
                        MessageBox.Show(@"Local file not found / dB file deleted");

                    }
                } while (i < checkedItemsList.Count);
            }

            else
            {
                MessageBox.Show(@"Please select a file to delete");
            }
        }

        public void PrintMessage(string text)
            {
                MessageBox.Show($@"{text} completed successfully");
            }
    }
}
