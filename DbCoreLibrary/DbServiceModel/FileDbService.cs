﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Metadata.Ecma335;

namespace DbCoreLibrary.DbServiceModel
{

    public class FileDbService
    {
        public readonly FileDbSerialization FileDbSerialization = new FileDbSerialization();
        public List<SerialFileDto> GetdBItems()
        {
            var dtoFileList = new List<SerialFileDto>();


            using (var context = new FiledbContext())
            {
                var fileList = context.SerializedFile.ToList();
                foreach (SerializedFile dbfile in fileList)
                {
                    var fileDto = SerialFileDto.MapTo(dbfile);
                    dtoFileList.Add(fileDto);
                }
                return dtoFileList;
            }
        }

        public SerialFileDto GetDetails(int? id)
        {
            using (var context = new FiledbContext())
            {
                var serializedFile = context.SerializedFile
                    .FirstOrDefault(m => m.Id == id);
                var serialFileDto = SerialFileDto.MapTo(serializedFile);
                return serialFileDto;
            }
        }

        public SerialFileDto GetEdit(int? id)
        {
            using (var context = new FiledbContext())
            {
                var serializedFile = context.SerializedFile
                    .FirstOrDefault(m => m.Id == id);
                var serialFileDto = SerialFileDto.MapTo(serializedFile);
                return serialFileDto;
            }
        }

        public bool PerformEdit(int id, SerialFileDto serialFileDto)
        {
            var serializedFile = SerialFileDto.MapTo(serialFileDto);
            if (id != serializedFile.Id)
            {
                return false;
            }

            using (var context = new FiledbContext())
            {                   
                context.Update(serializedFile);
                context.SaveChanges();
            }
            return true;
          
        }

        public bool FileCreate(SerialFileDto serialFileDto)
        {           

            if (IsDuplicate(serialFileDto.Name))
                return false;

            using (var context = new FiledbContext())
            {
                var serializedFile = SerialFileDto.MapTo(serialFileDto);
                context.SerializedFile.Add(serializedFile);
                context.SaveChanges();                  
            }
            return true;
        }

        public bool FileDbUpload(string fileName)
        {
            const string localpathrooth = "D:\\App\\TextFileDemoApp\\TextFileDemoApp\\bin\\Debug\\";
            var localPath = $@"{localpathrooth}{fileName}";

            if (!File.Exists(localPath)) return false;

            if (IsDuplicate(fileName))
                return false;
            
            using (var context = new FiledbContext())
            {
                var fileDto = new SerialFileDto
                {
                    Name = fileName.Split('.')[0],
                    Extension = fileName.Split('.')[1],
                    FileContent = File.ReadAllText(localPath),
                };

                var file = SerialFileDto.MapTo(fileDto);

                context.SerializedFile.Add(file);
                context.SaveChanges();
            }
            return true;
        }

        public bool IsDuplicate(string fileName)
        {
            var dbFileName = fileName.Split('.')[0];
            var isDuplicate = false;
            var context = new FiledbContext();
            if (context.SerializedFile.Any(s => s.Name.Contains(dbFileName)))
                isDuplicate = true;
            return isDuplicate;
        }

        public bool FileDelete(List<int?> checkedIds)
        {
            if (checkedIds.Count == 0)
            {
                return false;
            }
            else
            {
                using (var context = new FiledbContext())
                {
                    foreach (var id in checkedIds)
                    {

                        var fileToDelete = context.SerializedFile.FirstOrDefault(s => s.Id == id);
                        try
                        {
                            if (fileToDelete != null) context.Remove(fileToDelete);
                            context.SaveChanges();
                        }
                        catch (ArgumentNullException)
                        {
                            return false;
                        }
                    }
                    return true;
                }
            }
        }

        public bool FileDbDownload(SerialFileDto serialFileDto)
        {
            //if (serialFileDtoList.Count == 0)
            //{
            //    return false;
            //}

            //else
            //{
            //    using (var context = new FiledbContext())
            //    {
            //        for (int i = 0; i < serialFileDtoList.Count; i++)
            //        {
            //            int checkedItemId = serialFileDtoList[i].Id;
            //            var checkedItemName = context.SerializedFile.FirstOrDefault(x =>
            //            x.Id == checkedItemId)?.Name;
            //            var checkedItemContent = context.SerializedFile.FirstOrDefault(x =>
            //            x.Id == checkedItemId)?.FileContent;
            //            var checkedItemExtension = "." + serialFileDtoList[i].Extension.ToString();

            //            SerializedFile file = fileDbSerialization.CreateFile(checkedItemName, checkedItemExtension, checkedItemContent);

            //            switch (checkedItemExtension)
            //            {
            //                case ".xml":
            //                    fileDbSerialization.XmlSerializeToFile(SerialFileDto.MapTo(file));
            //                    break;
            //                case ".json":
            //                    fileDbSerialization.JsonSerializeToFile(SerialFileDto.MapTo(file));
            //                    break;
            //                case ".bin":
            //                    fileDbSerialization.BinarySerializeToFile(SerialFileDto.MapTo(file));
            //                    break;
            //                default:
            //                    return false;
            //            }
            //        }
            //    }
            return true;
            //}
        }
    }
}
//    else if (checkedItemsNb > 1)
//            {
//                var checkedItemsList = GetCheckedItemsList();

//                List<SerializedFile> serializedItemsList = new List<SerializedFile>();
//                foreach (var file in checkedItemsList)
//                {
//                    string checkedExt = file.Extension;
//                    switch (checkedExt)
//                    {
//                        case ".xml":
//                            SerializedFile xmlSerializedFile = _fileSerialization.XmlSerializeToFile(SerializedFileDto.MapTo(file));
//                            serializedItemsList.Add(xmlSerializedFile);

//                            break;
//                        case ".json":
//                            SerializedFile jsonSerializedFile = _fileSerialization.JsonSerializeToFile(SerializedFileDto.MapTo(file));
//                            serializedItemsList.Add(jsonSerializedFile);

//                            break;
//                        case ".bin":
//                            SerializedFile binSerializedFile = _fileSerialization.JsonSerializeToFile(SerializedFileDto.MapTo(file));
//                            serializedItemsList.Add(binSerializedFile);

//                            break;
//                        default:
//                            MessageBox.Show(@"Please select a format to download");
//                            return;
//                    }
//                }

//                bool isDownloaded = _fileDbService.ZipFileDbDownload(serializedItemsList);
//                if (isDownloaded)
//                {
//                    MessageBox.Show(@"Zip download done");
//                    return;
//                }
//                else
//                {
//                    MessageBox.Show(@"Please Select a file to download");
//                    return;
//                }
//            }
//            else
//            {
//                MessageBox.Show(@"Please select a file to download");
//            }
//        }


//        const string LOCALPATHROOTH = "D:\\App\\TextFileDemoApp\\Serialized dB downloaded\\Files.zip";

//            string zipPath = $@"{LOCALPATHROOTH}";

//            foreach (var file in checkedItemsList)
//            {
//                if (file == null)
//                {

//                    return false;
//                }

//                else
//                {
//                    using (FileStream zipToOpen = new FileStream(zipPath, FileMode.OpenOrCreate))
//                    {
//                        using (ZipArchive archive = new ZipArchive(zipToOpen, ZipArchiveMode.Update))
//                        {

//        ZipArchiveEntry readmeEntry =
//                                archive.CreateEntry(file.Name + file.Extension);
//    }
//                            using (StreamWriter writer = new StreamWriter(readmeEntry.Open()))
//                            {
//                                writer.Write(file.FileContent);
//                                writer.Close();
//                                return true;
//                            }
//                        }
//                    }
//                }
//            }

//            return false;
//        }


//    }
//}
