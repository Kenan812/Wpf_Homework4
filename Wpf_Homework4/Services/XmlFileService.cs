using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Wpf_Homework4.Model;

namespace Wpf_Homework4.Services
{
    class XmlFileService : IFileService
    {
        XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Friend>));

        public List<Friend> LoadFriendsFile(string filename)
        {
            List<Friend> friends = new List<Friend>();

            using (var ser = new StreamReader(filename))
            {
                friends = (List<Friend>)xmlSerializer.Deserialize(ser);
            }

            return friends;
        }

        public void SaveFriendsFile(string filename, List<Friend> friends)
        {
            using (var ser = new StreamWriter(filename))
            {
                xmlSerializer.Serialize(ser, friends);
            }
        }
    }
}
