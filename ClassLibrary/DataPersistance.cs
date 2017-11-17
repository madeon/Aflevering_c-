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

        
        public async void SerializeObject<T>(T serializableObject)
        {

            FileStream fileStream = new FileStream(@"C:\Users\Mathias\Dropbox\SOFTWARE - SDU\5 Semester\C#\Aflevering\Aflevering_2_UWP\UWP\XML\Test.xml", FileMode.Append);

            if (serializableObject == null) { return; }

            try
            {
                XmlDocument xmlDocument = new XmlDocument();
                XmlSerializer serializer = new XmlSerializer(serializableObject.GetType());
                using (MemoryStream stream = new MemoryStream())
                {
                    serializer.Serialize(stream, serializableObject);
                    stream.Position = 0;
                    xmlDocument.Load(stream);
                    xmlDocument.Save(fileStream);
                }
            }
            catch (Exception ex)
            {
                //Log exception here
            }
        }


        public static void ObjectToXML<T>(T obj, string filePath)
        {
            XmlSerializer s = new XmlSerializer(typeof(T));
            
            var xml = "";

            using (var sww = new StringWriter())
            {
                using (XmlWriter writer = XmlWriter.Create(sww))
                {
                    s.Serialize(writer, obj);
                    xml = sww.ToString(); // Your XML
                }
            }

        }
    }
}
