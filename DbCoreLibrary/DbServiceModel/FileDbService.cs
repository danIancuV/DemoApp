using DbCoreLibrary.SerializedFileModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;

namespace DbCoreLibrary.FileServiceModel
{

    public class FileDbService
    {
        public bool FileLocalCreate(SerialFileDto file)
        {
            if (file != null)
            {
                string path =
                    $@"D:\\App\\TextFileDemoApp\\TextFileDemoApp\\bin\\Debug\\{file.Name}{file.Extension}";
                using (var fileStream = new StreamWriter(path))
                {
                    {
                        fileStream.Write(file.FileContent);
                        fileStream.Close();
                    }
                }

                return true;
            }
            else
            {
                return false;
            }

        }

        public bool FileDbUpload(string fileName)
        {
            const string LOCALPATHROOTH = "D:\\App\\TextFileDemoApp\\TextFileDemoApp\\bin\\Debug\\";
            string localPath = $@"{LOCALPATHROOTH}{fileName}";

            if (File.Exists(localPath))
            {
                var db = new filedbContext();

                var fileModel = new SerialFileDto
                {
                    Name = fileName.Split('.')[0],
                    Extension = fileName.Split('.')[1],
                    FileContent = File.ReadAllText(localPath),
                };

                var file = SerialFileDto.MapTo(fileModel);

                db.SerializedFiles.Add(file);
                db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool ZipFileDbDownload(List<SerializedFile> checkedItemsList)
        {
            const string LOCALPATHROOTH = "D:\\App\\TextFileDemoApp\\Serialized dB downloaded\\Files.zip";

            string zipPath = $@"{LOCALPATHROOTH}";

            foreach (var file in checkedItemsList)
            {
                if (file == null)
                {

                    return false;
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
                                return true;
                            }
                        }
                    }
                }
            }

            return false;
        }

        public bool FileDelete(List<SerializedFile> checkedItemsList)
        {
            var db = new filedbContext();
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
                    }
                    else if (dbFile == null)
                    {
                        File.Delete(localPath);
                    }
                    else
                    {
                        db.SerializedFiles.Remove(dbFile);
                        db.SaveChanges();
                        checkedItemsList.Remove(checkedItemsList[i]);
                    }
                } while (i < checkedItemsList.Count);
                return true;
            }
            return false;
        }
    }
}
