using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Newtonsoft.Json;

namespace DbCoreLibrary.DbServiceModel
{
    public class FileDbSerialization
    {

        public SerializedFile CreateFile(string fileName, string fileExt, string fileContent)
        {
            return new SerializedFile
            {
                Name = fileName,
                FileContent = fileContent,
                Extension = fileExt
            };
        }

        public SerializedFile XmlSerializeToFile(SerialFileDto file)
        {
            var serializer = new System.Xml.Serialization.XmlSerializer(typeof(SerialFileDto));
            var path = $@"D:\\App\\TextFileDemoApp\\Serialized dB downloaded\\{file.Name}{file.Extension}";
            var localFile = File.Create(path);
            serializer.Serialize(localFile, file);
            localFile.Close();
           
            var serializedItemContent = ReadFile(file.Name + file.Extension, path);

            SerializedFile serializedFile =
                CreateFile(file.Name, file.Extension, serializedItemContent);

            return serializedFile;
        }

        public SerializedFile JsonSerializeToFile(SerialFileDto file)
        {
            var serializer = new JsonSerializer();
            var path = $@"D:\\App\\TextFileDemoApp\\Serialized dB downloaded\\{file.Name}{file.Extension}";
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

        public SerializedFile BinarySerializeToFile(SerialFileDto file)
        {
            var path = $@"D:\\App\\TextFileDemoApp\\Serialized dB downloaded\\{file.Name}{file.Extension}";
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

        public string ReadFile(string file, string path)
        {

            if (File.Exists(path))
            {
                using (var stream = File.OpenRead(path))
                {
                    using (var reader = new StreamReader(stream))
                    {
                        string text = reader.ReadToEnd();
                        return text;
                    }
                }
            }
            else
            {
                return null;
            }
        }
    }
}
