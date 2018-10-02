using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Runtime.Remoting.Messaging;

namespace FileClassLibrary.FileServiceModel
{

    public class FileLocalService
    {
        public readonly List<SerializedFileDto> FileDtoList = new List<SerializedFileDto>();
        public List<SerializedFileDto> FileGridUpload(string fileName)
        {
            const string localpathrooth = "D:\\App\\TextFileDemoApp\\TextFileDemoApp\\bin\\Debug\\";
            var localPath = $@"{localpathrooth}{fileName}";

            var isDuplicate = IsDuplicate(fileName);

            if (isDuplicate)
                return FileDtoList;
            if (File.Exists(localPath))
            {
                var fileModel = new SerializedFileDto
                {
                    Name = fileName.Split('.')[0],
                    Extension = fileName.Split('.')[1],
                    FileContent = File.ReadAllText(localPath),
                };

                FileDtoList.Add(fileModel);
                return FileDtoList;
            }
            else
            {
                return null;
            }

        }

        public bool IsDuplicate(string fileName)
        {
            var isDuplicate = false;
            if (FileDtoList.Count != 0)
            {               
                foreach (var file in FileDtoList)
                {
                    if (fileName != file.Name + "." + file.Extension) continue;
                    isDuplicate = true;
                    break;
                }
            }
            else
            {
                return false;
            }

            return isDuplicate;
        }

        public bool ZipFileArchive(List<SerializedFileDto> serializedItemsList)
        {
            const string localpathrooth = "D:\\App\\TextFileDemoApp\\Serialized dB downloaded\\Files.zip";

            string zipPath = $@"{localpathrooth}";

            IEnumerable<SerializedFileDto> fileList = serializedItemsList.Where(s => s != null).ToList();           

            foreach (var file in fileList)
            {
                using (var zipToOpen = new FileStream(zipPath, FileMode.OpenOrCreate))
                {
                    using (var archive = new ZipArchive(zipToOpen, ZipArchiveMode.Update))
                    {
                        var readmeEntry =
                            archive.CreateEntry(file.Name + file.Extension);
                        using (var writer = new StreamWriter(readmeEntry.Open()))
                        {
                            writer.Write(file.FileContent);
                            writer.Close();

                        }
                    }
                }
            }
            return true;
        }

        public List<SerializedFileDto> FileDelete(List<SerializedFileDto> checkedItemsList)
        {
            const int i = 0;

            if (checkedItemsList.Count == 0) return null;
            do
            {
                var checkedfileName = checkedItemsList[i].Name;
                const string checkedfileExt = ".txt";
                var localPath =
                    $@"D:\\App\\TextFileDemoApp\\TextFileDemoApp\\bin\\Debug\\{checkedfileName}{checkedfileExt}";

                for (var j = 0; j < FileDtoList.Count; j++)
                {
                    if (checkedfileName == FileDtoList[j].Name)
                    {
                        FileDtoList.Remove(FileDtoList[j]);
                    }
                }

                if (!File.Exists(localPath)) continue;
                checkedItemsList.Remove(checkedItemsList[i]);
                File.Delete(localPath);


            } while (i < checkedItemsList.Count);

            return FileDtoList;
        }
    }
}

