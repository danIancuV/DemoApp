using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Newtonsoft.Json;

namespace FileClassLibrary.FileServiceModel
{
    public class FileSerialization: FileSelection
    {

        public SerializedFile CreateFile(string fileName, string ext, string fileContent)
        {
            return new SerializedFile
            {
                Name = fileName,
                FileContent = fileContent,
                Extension = ext
            };
        }

        public SerializedFile XmlSerializeToFile(SerializedFileDto file)
        {
            var serializer = new System.Xml.Serialization.XmlSerializer(typeof(SerializedFileDto));
            var path = $@"D:\\App\\TextFileDemoApp-master\\Serialized dB downloaded\\{file.Name}{file.Extension}";
            var localFile = File.Create(path);
            serializer.Serialize(localFile, file);
            localFile.Close();
           
            var serializedItemContent = ReadFile(file.Name + file.Extension, path);

            SerializedFile serializedFile =
                CreateFile(file.Name, file.Extension, serializedItemContent);

            return serializedFile;
        }

        public SerializedFile JsonSerializeToFile(SerializedFileDto file)
        {
            var serializer = new JsonSerializer();
            var path = $@"D:\\App\\TextFileDemoApp-master\\Serialized dB downloaded\\{file.Name}{file.Extension}";
            using (var fileStream = new StreamWriter(path))
            {
                using (var writer = new JsonTextWriter(fileStream))
                {
                    serializer.Serialize(writer, file);
                }
            }
            var serializedItemContent = ReadFile(file.Name + file.Extension, path);

            SerializedFile serializedFile =
                CreateFile(file.Name, file.Extension, serializedItemContent);

            return serializedFile;
        }

        public SerializedFile BinarySerializeToFile(SerializedFileDto file)
        {
            var path = $@"D:\\App\\TextFileDemoApp-master\\Serialized dB downloaded\\{file.Name}{file.Extension}";
            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                var serializer = new BinaryFormatter();
                serializer.Serialize(fileStream, file);
            }
            var serializedItemContent = ReadFile(file.Name + file.Extension, path);

            SerializedFile serializedFile =
                CreateFile(file.Name, file.Extension, serializedItemContent);

            return serializedFile;
        }
    }
}
