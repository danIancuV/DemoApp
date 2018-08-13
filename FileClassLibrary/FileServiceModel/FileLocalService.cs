using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;

namespace FileClassLibrary.FileServiceModel
{

    public class FileLocalService
    {
        public bool FileLocalCreate(SerializedFileDto file)
        {
            if (file != null)
            {
                string path =
                    $@"D:\\App\\TextFileDemoApp-monday-commit-6-august\\TextFileDemoApp\\bin\\Debug\\{file.Name}{file.Extension}";
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

        

        public SerializedFileDto FileGridUpload(string fileName)
        {
            const string LOCALPATHROOTH = "D:\\App\\TextFileDemoApp-monday-commit-6-august\\TextFileDemoApp\\bin\\Debug\\";
            string localPath = $@"{LOCALPATHROOTH}{fileName}";

            

            if (File.Exists(localPath))
            {              

                var fileModel = new SerializedFileDto
                {
                    Name = fileName.Split('.')[0],
                    Extension = fileName.Split('.')[1],
                    FileContent = File.ReadAllText(localPath),
                };


                return fileModel;
            }
            
            else
            {
                return null;
            }

        }

        public bool ZipFileArchive(List<SerializedFileDto> checkedItemsList)
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

        public bool FileDelete(List<SerializedFileDto> checkedItemsList)
        {           
            int i = 0;

            if (checkedItemsList.Count != 0)
            {
                do
                {
                    var checkedfileName = checkedItemsList[i].Name;
                    var checkedfileExt = ".txt";
                    var localPath =
                        $@"D:\\App\\TextFileDemoApp\\TextFileDemoApp\\bin\\Debug\\{checkedfileName}{checkedfileExt}";

                    if (File.Exists(localPath))
                    {
                        checkedItemsList.Remove(checkedItemsList[i]);
                        File.Delete(localPath);
                    }

                } while (i < checkedItemsList.Count);

                return true;
            }
            return false;
        }
    }
}
