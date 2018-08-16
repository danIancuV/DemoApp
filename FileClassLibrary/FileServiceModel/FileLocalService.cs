using System.Collections.Generic;
using System.IO;
using System.IO.Compression;

namespace FileClassLibrary.FileServiceModel
{

    public class FileLocalService
    {

        List<SerializedFileDto> fileDtoList = new List<SerializedFileDto>();
        public List<SerializedFileDto> FileGridUpload(string fileName)
        {
            
            const string LOCALPATHROOTH = "D:\\App\\TextFileDemoApp\\TextFileDemoApp\\bin\\Debug\\";
            string localPath = $@"{LOCALPATHROOTH}{fileName}";

            if (File.Exists(localPath))
            {              
                var fileModel = new SerializedFileDto
                {
                    Name = fileName.Split('.')[0],
                    Extension = fileName.Split('.')[1],
                    FileContent = File.ReadAllText(localPath),
                };
                fileDtoList.Add(fileModel);
                return fileDtoList;
            }
            
            else
            {
                return null;
            }
        }

        public bool ZipFileArchive(List<SerializedFileDto> serializedItemsList)
        {
            const string LOCALPATHROOTH = "D:\\App\\TextFileDemoApp\\Serialized dB downloaded\\Files.zip";

            string zipPath = $@"{LOCALPATHROOTH}";

            foreach (var file in serializedItemsList)
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
                                
                            }
                        }
                    }
                }
            }
            return true;
        }

        public List<SerializedFileDto> FileDelete(List<SerializedFileDto> checkedItemsList)
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

                    for (int j = 0; j < fileDtoList.Count; j++)
                    {
                        if (checkedfileName == fileDtoList[j].Name)
                        {
                            fileDtoList.Remove(fileDtoList[j]);
                        }

                    }

                    if (File.Exists(localPath))
                    {
                        checkedItemsList.Remove(checkedItemsList[i]);
                        File.Delete(localPath);
                    }
                

                } while (i < checkedItemsList.Count);

                return fileDtoList;
            }
            return null;
        }
    }
}
