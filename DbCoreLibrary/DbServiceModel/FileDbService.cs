using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;

namespace DbCoreLibrary.DbServiceModel
{

    public class FileDbService
    {

        public List<SerialFileDto> GetdBItems()
        {
            List<SerialFileDto> dtoFileList = new List<SerialFileDto>();


            using (var context = new FiledbContext())
            {
                var fileList = context.SerializedFile.ToList();
                foreach (SerializedFile dbfile in fileList)
                {
                    SerialFileDto fileDto = SerialFileDto.MapTo(dbfile);
                    dtoFileList.Add(fileDto);
                }
                return dtoFileList;
            }

        }

        public bool FileDelete(List<int> ids)
        {
            if (ids.Count == 0)
            {
                return false;
            }
            else
            {
                using (var context = new FiledbContext())
                {
                    foreach (var id in ids)
                    {
                        var fileToDelete = context.SerializedFile.FirstOrDefault(s => s.Id == id);
                        context.Remove(fileToDelete);
                        context.SaveChanges();
                    }
                    return true;
                }
            }
        }


        public bool FileDbUpload(string fileName)
        {
            const string LOCALPATHROOTH = "D:\\App\\TextFileDemoApp\\TextFileDemoApp\\bin\\Debug\\";
            string localPath = $@"{LOCALPATHROOTH}{fileName}";

            if (File.Exists(localPath))
            {
                var db = new FiledbContext();

                var fileModel = new SerialFileDto
                {
                    Name = fileName.Split('.')[0],
                    Extension = fileName.Split('.')[1],
                    FileContent = File.ReadAllText(localPath),
                };

                var file = SerialFileDto.MapTo(fileModel);

                db.SerializedFile.Add(file);
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


    }
}
