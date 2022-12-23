using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
namespace Проект
{
    public static class SerializedClass
    {
        public static List<Person> PersonList = new List<Person>();
        public static List<Rayon> RayonList = new List<Rayon>();
        private static XmlSerializer PersonSerialization = new XmlSerializer(typeof(List<Person>));
        private static string pathtosave = Path.GetFullPath("Persons.xml");

        public static bool SerializePerson()
        {
            try
            {
                if (File.Exists(pathtosave))
                    File.WriteAllText(pathtosave, string.Empty);
                FileStream fileStream = new FileStream(pathtosave, FileMode.OpenOrCreate);
                using (fileStream)
                {
                    PersonSerialization.Serialize(fileStream, PersonList);
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
        public static bool DeSerializePerson()
        {
            try
            {
                FileStream fileStream = new FileStream(pathtosave, FileMode.Open);
                using (fileStream)
                {
                    PersonList = (List<Person>)PersonSerialization.Deserialize(fileStream);
                    return true;
                }

            }
            catch
            {
                return false;
            }
        }
    }
}
