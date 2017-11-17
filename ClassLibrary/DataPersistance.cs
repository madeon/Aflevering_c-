using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace ClassLibrary
{
    public class DataPersistance
    {
        public async void SaveDataToXML(object obj, string fileName)
        {
            var serializer = new XmlSerializer(obj.GetType());
            
            MemoryStream memoryStream = new MemoryStream();

            using (var stream = new StreamWriter(memoryStream))
            {
                serializer.Serialize(stream, obj);
            }
        }

        public async void Save<T>(T file, String path)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            
            using (var fileStream = new FileStream(path, FileMode.Open, FileAccess.ReadWrite))
            using (StreamWriter writer = new StreamWriter(fileStream, Encoding.UTF8))
            {
                serializer.Serialize(writer, file);
            }
        }
    }
}
