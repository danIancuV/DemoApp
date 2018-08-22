using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Newtonsoft.Json;

namespace FileClassLibrary.FileServiceModel
{
    public class FileSerialization
    {

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

        public SerializedFileDto CreateFile(string fileName, string ext, string fileContent)
        {
            return new SerializedFileDto
            {
                Name = fileName,
                FileContent = fileContent,
                Extension = ext
            };
        }

        public SerializedFileDto XmlSerializeToFile(SerializedFileDto file)
        {
            var serializer = new System.Xml.Serialization.XmlSerializer(typeof(SerializedFileDto));
            var path = $@"D:\\App\\TextFileDemoApp\\Serialized dB downloaded\\{file.Name}{file.Extension}";
            var localFile = File.Create(path);
            serializer.Serialize(stream: localFile, o: file);
            localFile.Close();
           
            var serializedItemContent = ReadFile(file.Name + file.Extension, path);

            var serializedFile =
                CreateFile(file.Name, file.Extension, serializedItemContent);

            return serializedFile;
        }

        public SerializedFileDto JsonSerializeToFile(SerializedFileDto file)
        {
            var serializer = new JsonSerializer();
            var path = $@"D:\\App\\TextFileDemoApp\\Serialized dB downloaded\\{file.Name}{file.Extension}";
            using (var fileStream = new StreamWriter(path))
            {
                using (var writer = new JsonTextWriter(fileStream))
                {
                    serializer.Serialize(jsonWriter: writer, value: file);
                }
            }
            var serializedItemContent = ReadFile(file.Name + file.Extension, path);

            var serializedFile =
                CreateFile(file.Name, file.Extension, serializedItemContent);

            return serializedFile;
        }

        public SerializedFileDto BinarySerializeToFile(SerializedFileDto file)
        {
            var path = $@"D:\\App\\TextFileDemoApp\\Serialized dB downloaded\\{file.Name}{file.Extension}";
            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                var serializer = new BinaryFormatter();
                serializer.Serialize(fileStream, file);
            }
            var serializedItemContent = ReadFile(file.Name + file.Extension, path);

            var serializedFile =
                CreateFile(file.Name, file.Extension, serializedItemContent);

            return serializedFile;
        }
    }
}
