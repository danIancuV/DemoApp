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
            var context = new FiledbContext();
            
             List<SerializedFile> checkedFileList = context.SerializedFile.Where(x => ids.Contains(x.Id)).ToList();
                

          
            int i = 0;

            if (ids.Count == 0)
            {
                do
                {
                    var checkedfileName = checkedFileList[i].Name;
                    var checkedfileExt = checkedFileList[i].Extension;
                    var localPath =
                        $@"D:\\App\\TextFileDemoApp\\TextFileDemoApp\\bin\\Debug\\{checkedfileName}{checkedfileExt}";
                    var dbFile = context.SerializedFile.FirstOrDefault(x =>
                        x.Name == checkedfileName);
                    if ((dbFile != null) && (File.Exists(localPath)))
                    {
                        context.SerializedFile.Remove(dbFile);
                        context.SaveChanges();
                        checkedFileList.Remove(checkedFileList[i]);
                        File.Delete(localPath);
                    }
                    else if (dbFile == null)
                    {
                        File.Delete(localPath);
                    }
                    else
                    {
                        context.SerializedFile.Remove(dbFile);
                        context.SaveChanges();
                        checkedFileList.Remove(checkedFileList[i]);
                    }
                } while (i < checkedFileList.Count);
                return true;
            }
            return false;
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
